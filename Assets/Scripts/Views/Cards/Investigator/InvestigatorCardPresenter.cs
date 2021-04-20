using Arkham.Interactors;
using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardPresenter : IInitializable
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ICardsManager cardsManager;
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
            visibilityEvent.AddVisibilityAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddTextChangeAction((_) => RefreshAllCardsVisibility());
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeSelected = investigatorSelectorInteractor.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = investigatorSelectorInteractor.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}