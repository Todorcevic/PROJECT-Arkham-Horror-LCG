using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Zenject;
using Arkham.Repositories;

namespace Arkham.Presenters
{
    public class DeckCardPresenter : IInitializable
    {
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly ICardSelectorInteractors deckBuilderInteractor;
        [Inject] private readonly IDeckCardsManager deckCardsManager;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IVisibilityEvent visibilityEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.InvestigatorSelectedChanged += RefreshAllCardsVisibility;
            addCardEvent.DeckCardAdded += RefreshAllCardsVisibility;
            removeCardEvent.DeckCardRemoved += RefreshAllCardsVisibility;
            visibilityEvent.VisibilityChanged += RefreshAllCardsVisibility;
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility(string _) => RefreshAllCardsVisibility();

        private void RefreshAllCardsVisibility()
        {
            foreach (ICardVisualizable cardView in deckCardsManager.CardsList)
            {
                bool canBeSelected = deckBuilderInteractor.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = deckBuilderInteractor.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}
