using Arkham.Interactors;
using Arkham.EventData;
using Zenject;
using Arkham.Repositories;

namespace Arkham.Views
{
    public class DeckCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly ICardRemovedEvent removeCardEvent;
        [Inject] private readonly ICardAddedEvent addCardEvent;
        [Inject] private readonly ICardSelectorInteractors cardSelectorInteractor;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly IInvestigatorSelectedEvent selectInvestigatorEvent;
        [Inject] private readonly IVisibilityEvent visibilityEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.Subscribe((_) => RefreshAllCardsVisibility());
            addCardEvent.AddAction((_) => RefreshAllCardsVisibility());
            removeCardEvent.AddAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddVisibilityAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddTextChangeAction(RefreshAllCardsVisibility);
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
