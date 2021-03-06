using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorCardPresenter : IInitializable
    {
        [Inject] protected readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEventData;
        [Inject] private readonly IRemoveInvestigatorEvent removeInvestigatorEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addInvestigatorEventData.InvestigatorAdded += RefreshAllCardsVisibility;
            removeInvestigatorEvent.InvestigatorRemoved += RefreshAllCardsVisibility;
            RefreshAllCardsVisibility(null);
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility(string _)
        {
            foreach (ICardVisualizable cardView in investigatorCardsManager.CardsList)
            {
                bool canBeSelected = investigatorSelectorInteractor.CanThisCardBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }
    }
}