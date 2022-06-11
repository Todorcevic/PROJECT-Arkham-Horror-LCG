using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application.MainMenu
{
    public class SwitchInput : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private SwitchView switchView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => switchView.PointerClick();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) 
        {
            if (eventData.dragging) return;
            switchView.HoverOnEffect(); 
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => switchView.HoverOffEffect();
    }
}
