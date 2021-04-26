using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly IInvestigatorAddedEvent InvestigatorAddedEvent;
        [Inject] private readonly IInvestigatorRemovedEvent removeInvestigatorEvent;
        [Inject] private readonly IVisibilityEvent visibilityEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        public void Initialize()
        {
            startGameEvent.AddAction(RefreshAllInvestigatorsVisibility);
            InvestigatorAddedEvent.Subscribe((_) => RefreshAllInvestigatorsVisibility());
            removeInvestigatorEvent.Subscribe((_) => RefreshAllInvestigatorsVisibility());
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
