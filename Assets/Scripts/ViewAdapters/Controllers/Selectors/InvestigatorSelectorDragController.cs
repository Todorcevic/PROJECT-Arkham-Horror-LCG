using Arkham.EventData;
using Arkham.Views;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorDragController : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private static bool isDragging;
        [Inject] private readonly IChangeInvestigator changeInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [SerializeField, Required] private Transform removeZone;
        [SerializeField, Required] private InvestigatorSelectorView investigatorSelectorView;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (!isDragging) return;
            if (IsDragging(eventData)) return;
            investigatorSelectorView.HoverOnAudio();
            int positionToSwap = eventData.pointerDrag.transform.GetSiblingIndex();
            changeInvestigator.Swap(positionToSwap, investigatorSelectorView.Id);
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            investigatorSelectorView.BeginDragEffect();
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => investigatorSelectorView.DraggingEffect(eventData.position);

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            investigatorSelectorView.EndDragEffect();
            if (IsInRemoveZone(eventData))
                removeInvestigator.Removing(investigatorSelectorView.Id);
            else investigatorSelectorView.Arrange();
        }

        private bool IsDragging(PointerEventData eventData) => eventData.pointerDrag == gameObject;
        private bool IsInRemoveZone(PointerEventData eventData) => eventData.hovered.Contains(removeZone.gameObject);
    }
}
