using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Services;
using Arkham.Views;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Inject] private readonly IDoubleClickDetector clickDetector;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [SerializeField, Required] private InvestigatorSelectorView investigatorSelectorView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (clickDetector.IsDoubleClick(eventData.clickTime, eventData.pointerPress))
            {
                investigatorSelectorView.DoubleClickEffect();
                removeInvestigator.Removing(investigatorSelectorView.Id);
                selectInvestigator.Selecting(investigatorSelectorInteractor.LeadInvestigator);
            }
            else
            {
                investigatorSelectorView.ClickEffect();
                selectInvestigator.Selecting(investigatorSelectorView.Id);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            investigatorSelectorView.HoverOnEffect();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            investigatorSelectorView.HoverOffEffect();
        }
    }
}
