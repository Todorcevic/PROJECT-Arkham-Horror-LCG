using Arkham.EventData;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorDragController : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private static bool isDragging;
        [Inject] private readonly IChangeInvestigator changeInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [Title("RESOURCES")]
        [SerializeField, Required] private InvestigatorSelectorView selectorView;
        [SerializeField, Required, SceneObjectsOnly] private GameObject removeZone;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == gameObject) return;
            if (isDragging)
            {
                selectorView.Effects.HoverOnAudio();
                int positionToSwap = eventData.pointerDrag.transform.GetSiblingIndex();
                changeInvestigator.Swap(positionToSwap, selectorView.Id);
            }
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            selectorView.DragEffects.BeginningDrag();
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => selectorView.DragEffects.Dragging(eventData.position);

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            selectorView.DragEffects.EndingDrag();
            if (eventData.hovered.Contains(removeZone))
                removeInvestigator.RemoveInvestigator(selectorView.Id);
            else selectorView.SelectorMovement.Arrange();
        }
    }
}
