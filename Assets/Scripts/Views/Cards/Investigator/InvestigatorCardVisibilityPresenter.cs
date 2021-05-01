using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly StartGameEventDomain gameStartedEvent;
        [Inject] private readonly RemoveInvestigatorEventDomain InvestigatorSelectorEvent;
        [Inject] private readonly AddInvestigatorEventDomain investigatorAddEvent;
        [Inject] private readonly VisibilityEventDomain visibilityChangedEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly InvestigatorState investigatorSelectorInteractor;
        [Inject] private readonly SearchTextEventDomain searchTextEvent;

        /*******************************************************************/
        public void Initialize()
        {
            gameStartedEvent.Subscribe((_) => RefreshAllInvestigatorsVisibility());
            investigatorAddEvent.Subscribe((_) => RefreshAllInvestigatorsVisibility());
            InvestigatorSelectorEvent.Subscribe((_) => RefreshAllInvestigatorsVisibility());
            visibilityChangedEvent.Subscribe((_) => RefreshAllInvestigatorsVisibility());
            searchTextEvent.Subscribe(RefreshAllInvestigatorsVisibility);
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
