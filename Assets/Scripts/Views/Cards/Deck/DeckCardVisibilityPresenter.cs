using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly CardSelectorInteractor cardSelectorInteractor;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly RemoveCardEventDomain cardRemovedEvent;
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly InvestigatorSelectorEventDomain selectInvestigatorEvent;
        [Inject] private readonly VisibilityChangeEventDomain visibilityEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.Select((_) => RefreshAllCardsVisibility());
            addCardEvent.DeckCardAdded += (_) => RefreshAllCardsVisibility();
            cardRemovedEvent.DeckCardRemoved += (_) => RefreshAllCardsVisibility();
            visibilityEvent.VisibilityChanged += (_) => RefreshAllCardsVisibility();
            visibilityEvent.TextToSearchChanged += RefreshAllCardsVisibility;
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility()
        {
            foreach (CardView cardView in cardsManager.DeckList)
            {
                bool canBeSelected = cardSelectorInteractor.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = cardSelectorInteractor.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}
