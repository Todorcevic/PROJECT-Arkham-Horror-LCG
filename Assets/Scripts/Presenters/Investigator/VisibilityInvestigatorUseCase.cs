using Arkham.EventData;
using Arkham.Interactors;
using Zenject;

namespace Arkham.Views
{
    public class VisibilityInvestigatorUseCase : IInitializable
    {
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEvent;
        [Inject] private readonly IRemoveInvestigatorEvent removeInvestigatorEvent;
        [Inject] private readonly IVisibilityEvent visibilityEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        public void Initialize()
        {
            startGameEvent.AddAction(RefreshAllCardsVisibility);
            addInvestigatorEvent.AddAction((_) => RefreshAllCardsVisibility());
            removeInvestigatorEvent.AddAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddVisibilityAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddTextChangeAction(RefreshAllCardsVisibility);
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
