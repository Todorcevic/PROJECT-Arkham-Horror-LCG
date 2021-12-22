using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Application
{
    public class LeaderIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ButtonIcon leader;

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
