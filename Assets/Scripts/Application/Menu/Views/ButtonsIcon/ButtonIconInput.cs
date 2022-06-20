using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ButtonIconInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly InteractableAudio interactableAudio;
        [SerializeField] private ButtonIconView buttonIconView;

        /*******************************************************************/
        public void OnPointerClick(PointerEventData eventData)
        {
            if (buttonIconView.IsClickSound) interactableAudio.ClickSound();
            if (buttonIconView.IsInactive) buttonIconView.CantAdd();
            else buttonIconView.PointerClick();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            interactableAudio.HoverOnSound();
            buttonIconView.HoverOnEffect();
        }

        public void OnPointerExit(PointerEventData eventData) => buttonIconView.HoverOffEffect();
    }
}
