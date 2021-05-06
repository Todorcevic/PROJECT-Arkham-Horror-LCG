using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class InvestigatorsCardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectionInteractor investigatorSelectionFilter;
        [Inject] private readonly CardVisibilityInteractor visibilityService;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;

        /*******************************************************************/
        public void RefreshInvestigatorsVisibility()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Show(canBeShowed);
            }
        }

        public void RefreshInvestigatorsSelectability()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeSelected = investigatorSelectionFilter.CanThisCardBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }

        public void InvestigatorStateResolve(List<InvestigatorStateDTO> investigators)
        {
            foreach (InvestigatorStateDTO investigator in investigators)
            {
                if (investigator.State == InvestigatorState.Killed)
                    cardsManager.GetInvestigatorCard(investigator.Id).ChangeToKilledState();
                else if (investigator.State == InvestigatorState.Insane)
                    cardsManager.GetInvestigatorCard(investigator.Id).ChangeToInsaneState();
                else if (investigator.State == InvestigatorState.Retired)
                    cardsManager.GetInvestigatorCard(investigator.Id).ChangeToRetiredState();
            }
        }
    }
}
