using Arkham.EventData;
using Arkham.Interactors;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.View
{
    public class InvestigatorSelectorController : IInvestigatorSelectorController
    {
        [Inject] private readonly IRemoveInvestigator removeInvestigator;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IChangeInvestigator changeInvestigator;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;

        /*******************************************************************/
        public void DoubleClicked(string investigatorId)
        {
            removeInvestigator.Removing(investigatorId);
            selectInvestigator.Selecting(investigatorSelectorInteractor.LeadInvestigator);
        }

        public void Clicked(string investigatorId) => selectInvestigator.Selecting(investigatorId);

        public void Swaping(string investigatorId, int positionToSwap) => changeInvestigator.Swap(positionToSwap, investigatorId);

        public void EndingDrag(string investigatorId, PointerEventData eventData)
        {
            if (IsInRemoveZone(eventData)) DoubleClicked(investigatorId);
            else investigatorSelectorManager.GetSelectorById(investigatorId).ArrangeAnimation();
        }

        private bool IsInRemoveZone(PointerEventData eventData) => eventData.hovered.Contains(removeZone.gameObject);
    }
}
