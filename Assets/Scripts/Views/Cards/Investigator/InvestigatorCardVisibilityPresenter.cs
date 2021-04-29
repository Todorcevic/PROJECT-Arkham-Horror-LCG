using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly StartGameEventDomain gameStartedEvent;
        [Inject] private readonly InvestigatorSelectorEventDomain InvestigatorSelectorEvent;
        [Inject] private readonly VisibilityChangeEventDomain visibilityChangedEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        public void Initialize()
        {
            gameStartedEvent.GameStarted += (_) => RefreshAllInvestigatorsVisibility();
            InvestigatorSelectorEvent.Add((_) => RefreshAllInvestigatorsVisibility());
            InvestigatorSelectorEvent.Remove((_) => RefreshAllInvestigatorsVisibility());
            visibilityChangedEvent.VisibilityChanged += (_) => RefreshAllInvestigatorsVisibility();
            visibilityChangedEvent.TextToSearchChanged += RefreshAllInvestigatorsVisibility;
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
