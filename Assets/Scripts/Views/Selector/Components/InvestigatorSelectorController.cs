using Arkham.EventData;
using Arkham.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private static bool isDragging;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [Inject] private readonly IChangeInvestigator changeInvestigator;
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Title("RESOURCES")]
        [SerializeField, Required] private InvestigatorSelectorView selectorView;
        [SerializeField, Required] private InvestigatorSelectorEffects effects;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
            {
                effects.DoubleClickEffect();
                removeInvestigator.RemoveInvestigator(selectorView.Id);
            }
            else
            {
                effects.ClickEffect();
                selectInvestigator.SelectInvestigator(selectorView.Id);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == gameObject) return;
            if (isDragging)
            {
                effects.HoverOnAudio();
                int positionToSwap = eventData.pointerDrag.transform.GetSiblingIndex();
                changeInvestigator.Swap(positionToSwap, selectorView.Id);
            }
            else effects.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!isDragging) effects.HoverOffEffect();
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;
            effects.ImageUp();
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => effects.Dragging(eventData.position);

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            effects.ImageDown();
            effects.HoverOffEffect();
            if (effects.CanRemove(eventData))
                removeInvestigator.RemoveInvestigator(selectorView.Id);
            else selectorView.ArrangeTo();
        }
    }
}