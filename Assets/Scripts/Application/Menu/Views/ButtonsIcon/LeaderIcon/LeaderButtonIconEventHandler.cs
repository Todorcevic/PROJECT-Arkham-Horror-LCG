using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application.MainMenu
{
    public class LeaderButtonIconEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ButtonIconView leader;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            leader.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => leader.HoverOffEffect();
    }
}
