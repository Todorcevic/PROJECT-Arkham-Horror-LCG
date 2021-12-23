using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application
{
    public class LeaderButtonIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ButtonIconView leader;

        /*******************************************************************/
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            leader.OnPointerEnter(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            leader.OnPointerExit(eventData);
        }
    }
}
