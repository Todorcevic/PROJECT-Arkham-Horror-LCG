using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Zenject;

namespace Arkham.Presenters
{
    public class DeckCardPresenter : IInitializable
    {
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly ICardSelectorInteractors cardSelectorInteractor;
        [Inject] private readonly IDeckCardsManager deckCardsManager;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IVisibilityEvent visibilityEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.AddAction((_) => RefreshAllCardsVisibility());
            addCardEvent.AddAction((_) => RefreshAllCardsVisibility());
            removeCardEvent.AddAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddAction((_) => RefreshAllCardsVisibility());
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility()
        {
            foreach (ICardVisualizable cardView in deckCardsManager.CardsList)
            {
                bool canBeSelected = cardSelectorInteractor.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = cardSelectorInteractor.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}
