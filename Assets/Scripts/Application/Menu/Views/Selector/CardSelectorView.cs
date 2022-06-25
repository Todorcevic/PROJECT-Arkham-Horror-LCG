using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application.MainMenu
{
    public class CardSelectorView : MonoBehaviour, IShowable
    {
        private const float positionThreshold = 0.26f;
        private const string CANT_COMPLETE = "CantComplete";
        [Title("RESOURCES")]
        [SerializeField, Required] private RectTransform card;
        [SerializeField, Required] private RectTransform placeHolder;
        [SerializeField, Required] private CanvasGroup canvas;
        [SerializeField, Required] private Image image;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private TextMeshProUGUI cardName;
        [SerializeField, Required] private TextMeshProUGUI quantity;

        public string Id { get; private set; } = null;
        public bool MustReshow => !IsEmpty;
        public bool IsInactive => false;
        public bool IsEmpty => string.IsNullOrEmpty(Id);
        public Transform SelectorTransform => canvas.transform;
        public bool CanBeRemoved { get; set; }
        public Vector2 StartPosition => placeHolder.position;
        public Vector2 ShowPosition => new Vector2(placeHolder.position.x + Screen.width * positionThreshold, Screen.height * 0.5f);
        public Sprite FrontImage => image.sprite;
        public Sprite BackImage => null;

        /*******************************************************************/
        public void PointerEnter()
        {
            ChangeTextColor(Color.black);
            FillBackground(true);
        }

        public void PointerExit()
        {
            ChangeTextColor(Color.white);
            FillBackground(false);
        }

        public void SetSelector(string cardId, Sprite cardSprite = null)
        {
            Id = cardId;
            Activate(!IsEmpty);
            ChangeImage(cardSprite);

            void Activate(bool isOn) => canvas.blocksRaycasts = canvas.interactable = isOn;

            void ChangeImage(Sprite cardSprite)
            {
                canvas.alpha = cardSprite == null ? 0 : 1;
                image.sprite = cardSprite;
            }
        }

        public void SetName(string cardName) => this.cardName.text = cardName;

        public void SetQuantity(int amount) => quantity.text = (amount <= 1) ? string.Empty : "x" + amount.ToString();

        public void SetTransform(RectTransform toTransform)
        {
            card.SetParent(toTransform, worldPositionStays: false);
            card.localPosition = Vector3.zero;
        }

        public void SetCanBeRemoved(bool canBeRemoved)
        {
            background.color = canBeRemoved ? ViewValues.ENABLE_COLOR : ViewValues.DISABLE_COLOR;
            CanBeRemoved = canBeRemoved;
        }

        public void CantRemoveAnimation()
        {
            DOTween.Complete(CANT_COMPLETE);
            card.DOPunchPosition(Vector3.right * 10, ViewValues.STANDARD_TIME, 20, 5).SetId(CANT_COMPLETE);
        }

        private void ChangeTextColor(Color color)
        {
            cardName.DOColor(color, ViewValues.STANDARD_TIME);
            quantity?.DOColor(color, ViewValues.STANDARD_TIME);
        }

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, ViewValues.STANDARD_TIME);
    }
}
