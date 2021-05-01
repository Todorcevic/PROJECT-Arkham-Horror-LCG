using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly CardState cardSelectorInteractor;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly RemoveCardEventDomain cardRemovedEvent;
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly VisibilityEventDomain visibilityEvent;
        [Inject] private readonly SearchTextEventDomain searchTextEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            investigatorSelectEvent.Subscribe((_) => RefreshAllCardsVisibility());
            addCardEvent.Subscribe((_) => RefreshAllCardsVisibility());
            cardRemovedEvent.Subscribe((_) => RefreshAllCardsVisibility());
            visibilityEvent.Subscribe((_) => RefreshAllCardsVisibility());
            searchTextEvent.Subscribe(RefreshAllCardsVisibility);
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
