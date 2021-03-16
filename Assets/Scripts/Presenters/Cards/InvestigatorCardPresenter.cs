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
        [Inject] private readonly IStartGameEvent startGameEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addInvestigatorEventData.InvestigatorAdded += RefreshAllCardsVisibility;
            removeInvestigatorEvent.InvestigatorRemoved += RefreshAllCardsVisibility;
            startGameEvent.GameStarted += RefreshAllCardsVisibility;
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility(string _) => RefreshAllCardsVisibility();

        private void RefreshAllCardsVisibility()
        {
            foreach (ICardVisualizable cardView in investigatorCardsManager.CardsList)
            {
                bool canBeSelected = investigatorSelectorInteractor.CanThisCardBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }
    }
}