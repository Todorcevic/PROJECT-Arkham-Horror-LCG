using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorCardPresenter : IInitializable
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEventData;
        [Inject] private readonly IRemoveInvestigatorEvent removeInvestigatorEvent;
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly IVisibilityEvent visibilityEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addInvestigatorEventData.AddAction((_) => RefreshAllCardsVisibility());
            removeInvestigatorEvent.AddAction((_) => RefreshAllCardsVisibility());
            startGameEvent.AddAction(RefreshAllCardsVisibility);
            visibilityEvent.AddAction((_) => RefreshAllCardsVisibility());
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility()
        {
            foreach (ICardVisualizable cardView in investigatorCardsManager.CardsList)
            {
                bool canBeSelected = investigatorSelectorInteractor.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = investigatorSelectorInteractor.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}