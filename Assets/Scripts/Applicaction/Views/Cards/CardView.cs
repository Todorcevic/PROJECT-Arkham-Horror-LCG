using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private ICardController controller;
        [Inject] private readonly CardShowerPresenter showerController;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGroup;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [SerializeField, Required, ChildGameObjectsOnly] private Image image;
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField] private Color enableColor;
        [SerializeField] private Color disableColor;

        public string Id { get; private set; }
        public Sprite GetCardImage => image.sprite;
        public bool IsInactive { get; set; }

        /*******************************************************************/
        [Inject]
        private void Init(string id, Sprite sprite, ICardController controller)
        {
            name = Id = id;
            ChangeImage(sprite);
            this.controller = controller;
        }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging || IsInactive) return;
            ClickEffect();
            controller.Clicked(Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            HoverOnEffect();
            showerController.HoveredOn(new CardShowerDTO(Id, transform.position, isInLeftSide: true));
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            HoverOffEffect();
            showerController.HoveredOff();
        }

        private void ClickEffect() => audioInteractable.ClickSound();

        private void HoverOnEffect()
        {
            canvasGlow.DOFade(1, timeHoverAnimation);
            audioInteractable.HoverOnSound();
        }

        private void HoverOffEffect() => canvasGlow.DOFade(0, timeHoverAnimation);

        public void Activate(bool isEnable)
        {
            IsInactive = !isEnable;
            image.color = isEnable ? Color.white : Color.gray;
            glow.color = IsInactive ? disableColor : enableColor;
        }

        public void Show(bool isEnable) => gameObject.SetActive(isEnable);

        private void ChangeImage(Sprite sprite)
        {
            canvasGroup.alpha = sprite == null ? 0 : 1;
            image.sprite = sprite;
        }
    }
}
