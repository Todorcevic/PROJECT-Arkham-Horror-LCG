using Arkham.EventData;
using Arkham.Interactors;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardVisibilityPresenter : IInitializable
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
            startGameEvent.AddAction(RefreshAllInvestigatorsVisibility);
            addInvestigatorEvent.AddAction((_) => RefreshAllInvestigatorsVisibility());
            removeInvestigatorEvent.AddAction((_) => RefreshAllInvestigatorsVisibility());
            visibilityEvent.AddVisibilityAction((_) => RefreshAllInvestigatorsVisibility());
            visibilityEvent.AddTextChangeAction(RefreshAllInvestigatorsVisibility);
        }

        /*******************************************************************/
        private void RefreshAllInvestigatorsVisibility()
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
