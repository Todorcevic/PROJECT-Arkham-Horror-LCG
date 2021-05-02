using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class CardSelectorSensor : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly CardSelectorController controller;
        [Inject] private readonly CardShowerController showerController;
        [Title("RESOURCES")]
        [SerializeField, Required] private CanvasGroup canvas;
        [SerializeField, Required] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private TextMeshProUGUI cardName;
        [SerializeField, Required] private TextMeshProUGUI quantity;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        public string Id { private get; set; }

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            ClickEffect();
            controller.Clicked(Id);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            HoverOnEffect();
            showerController.HoveredOn(new CardShowerDTO(Id, Color.white, transform.position, isInLeftSide: false));
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            HoverOffEffect();
            showerController.HoveredOff();
        }

        public void Activate(bool isOn) => canvas.blocksRaycasts = canvas.interactable = isOn;

        private void ClickEffect() => interactableAudio.ClickSound();

        private void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate();
        }

        private void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverDesactivate();
        }

        private void HoverActivate()
        {
            ChangeTextColor(Color.black);
            FillBackground(true);
        }

        private void HoverDesactivate()
        {
            ChangeTextColor(Color.white);
            FillBackground(false);
        }

        private void ChangeTextColor(Color color)
        {
            cardName.DOColor(color, timeHoverAnimation);
            quantity?.DOColor(color, timeHoverAnimation);
        }

        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}
