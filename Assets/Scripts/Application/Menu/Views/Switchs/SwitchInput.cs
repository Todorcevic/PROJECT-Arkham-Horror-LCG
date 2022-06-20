using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SwitchInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private InteractableAudio interactableAudio;
        [SerializeField] private SwitchView switchView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            interactableAudio.ClickSound();
            switchView.PointerClick();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            interactableAudio.ClickSound();
            switchView.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => switchView.HoverOffEffect();
    }
}
