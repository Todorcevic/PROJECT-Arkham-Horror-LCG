using Arkham.Config;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardSelectorView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler, IShowable
    {
        private const float positionThreshold = 0.26f;
        private Tween cantComplete;
        [Inject] private readonly RemoveCardUseCase removeCardUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Title("RESOURCES")]
        [SerializeField, Required] private RectTransform card;
        [SerializeField, Required] private InteractableAudio interactableAudio;
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
        private bool CanBeRemoved { get; set; }
        public Vector2 StartPosition => transform.position;
        public Vector2 ShowPosition => new Vector2(transform.position.x + Screen.width * positionThreshold, Screen.height * 0.5f);
        public Sprite FrontImage => image.sprite;
        public Sprite BackImage => null;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            interactableAudio.ClickSound();
            if (CanBeRemoved) removeCardUseCase.Remove(Id, investigatorSelectorManager.InvestigatorSelected);
            else CantRemoveAnimation();

            void CantRemoveAnimation()
            {
                cantComplete.Complete();
                cantComplete = card.DOPunchPosition(Vector3.right * 10, ViewValues.STANDARD_TIME, 20, 5);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOnEffect();
            cardShowerPresenter.AddShowableAndShow(this);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            HoverOffEffect();
            cardShowerPresenter.RemoveShowableAndHide(this);

            void HoverOffEffect()
            {
                interactableAudio.HoverOffSound();
                ChangeTextColor(Color.white);
                FillBackground(false);
            }
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            HoverOnEffect();
            cardShowerPresenter.AddShowableAndShow(this);
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

        private void ChangeTextColor(Color color)
        {
            cardName.DOColor(color, ViewValues.STANDARD_TIME);
            quantity?.DOColor(color, ViewValues.STANDARD_TIME);
        }

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, ViewValues.STANDARD_TIME);

        private void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            ChangeTextColor(Color.black);
            FillBackground(true);
        }
    }
}
