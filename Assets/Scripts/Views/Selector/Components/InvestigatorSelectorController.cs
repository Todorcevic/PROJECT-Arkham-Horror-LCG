using Arkham.EventData;
using Arkham.Managers;
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
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Title("RESOURCES")]
        [SerializeField, Required] private InvestigatorSelectorView selectorView;
        [SerializeField, Required] private InvestigatorSelectorEffects effects;
        [SerializeField, Required] private Transform objectToDrag;

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
                effects.SwapPlaceHolder(eventData.pointerDrag.transform, transform);
                selectorView.ArrangeTo();
            }
            else effects.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!isDragging) effects.HoverOffEffect();
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            effects.ImageUp();
            isDragging = true;
        }

        void IDragHandler.OnDrag(PointerEventData eventData) => objectToDrag.position = eventData.position;

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
            effects.ImageDown();
            effects.HoverOffEffect();
            if (!eventData.hovered.Contains(transform.parent.gameObject))
            {
                removeInvestigator.RemoveInvestigator(selectorView.Id);
                return;
            }
            selectorView.ArrangeTo();
        }
    }
}
