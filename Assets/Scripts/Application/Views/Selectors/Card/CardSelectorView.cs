using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardSelectorView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IShowable
    {
        private Tween cantComplete;
        [Inject] private readonly RemoveCardUseCase removeCardUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly ShowCard showCard;
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform card;
        [SerializeField, Required] private InteractableAudio interactableAudio;
        [SerializeField, Required] private CanvasGroup canvas;
        [SerializeField, Required] private Image image;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private TextMeshProUGUI cardName;
        [SerializeField, Required] private TextMeshProUGUI quantity;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeAnimation;
        [SerializeField] private Color enableColor;
        [SerializeField] private Color disableColor;

        public string Id { get; private set; } = null;
        public bool IsEmpty => string.IsNullOrEmpty(Id);
        public Transform SelectorTransform => canvas.transform;
        private bool CanBeRemoved { get; set; }
        public Vector2 Position => transform.position;
        public Sprite FrontImage => image.sprite;
        public Sprite BackImage => null;

        /*******************************************************************/
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

        public Tween ShowAnimation() => DOTween.Sequence()
            .AppendCallback(() => SelectorTransform.localScale = Vector3.zero)
            .Append(SelectorTransform.DOScale(1, timeAnimation).SetDelay(timeAnimation));

        public void SetCanBeRemoved(bool canBeRemoved)
        {
            background.color = canBeRemoved ? enableColor : disableColor;
            CanBeRemoved = canBeRemoved;
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            ClickEffect();
            if (CanBeRemoved) removeCardUseCase.Remove(Id, investigatorSelectorManager.CurrentInvestigatorId);
            else CantRemoveAnimation();

            void ClickEffect() => interactableAudio.ClickSound();

            void CantRemoveAnimation()
            {
                cantComplete.Complete();
                cantComplete = card.DOPunchPosition(Vector3.right * 10, timeAnimation, 20, 5);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData?.dragging ?? false) return;
            HoverOnEffect();
            showCard.Set(this);
            showCard.ShowAnimation();

            void HoverOnEffect()
            {
                interactableAudio.HoverOnSound();
                ChangeTextColor(Color.black);
                FillBackground(true);
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOffEffect();
            showCard.Hide();

            void HoverOffEffect()
            {
                interactableAudio.HoverOffSound();
                ChangeTextColor(Color.white);
                FillBackground(false);
            }
        }

        private void ChangeTextColor(Color color)
        {
            cardName.DOColor(color, timeAnimation);
            quantity?.DOColor(color, timeAnimation);
        }

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeAnimation);
    }
}
