using Arkham.EventData;
using Arkham.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Title("RESOURCES")]
        [SerializeField, Required] private InvestigatorSelectorView selectorView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
            {
                selectorView.Effects.DoubleClickEffect();
                removeInvestigator.RemoveInvestigator(selectorView.Id);
            }
            else
            {
                selectorView.Effects.ClickEffect();
                selectInvestigator.SelectInvestigator(selectorView.Id);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            selectorView.Effects.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            selectorView.Effects.HoverOffEffect();
        }
    }
}