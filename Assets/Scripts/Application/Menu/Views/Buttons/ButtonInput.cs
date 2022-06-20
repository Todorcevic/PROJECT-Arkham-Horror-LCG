using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ButtonInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly InteractableAudio interactableAudio;
        [SerializeField] private ButtonView buttonView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            if (buttonView.IsInactive) return;
            interactableAudio.ClickSound();
            buttonView.PointerClick();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            if (buttonView.IsInactive) return;
            interactableAudio.HoverOnSound();
            buttonView.HoverActivate(true);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            if (buttonView.IsInactive) return;
            buttonView.HoverActivate(false);
        }
    }
}
