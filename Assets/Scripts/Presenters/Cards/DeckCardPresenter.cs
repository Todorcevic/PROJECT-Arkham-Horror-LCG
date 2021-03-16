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
        [Inject] private readonly ICardSelectorInteractors deckBuilderInteractor;
        [Inject] private readonly IDeckCardsManager deckCardsManager;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.InvestigatorSelectedChanged += RefreshAllCardsVisibility;
            addCardEvent.DeckCardAdded += RefreshAllCardsVisibility;
            removeCardEvent.DeckCardRemoved += RefreshAllCardsVisibility;
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility(string _)
        {
            foreach (ICardVisualizable cardView in deckCardsManager.CardsList)
            {
                bool canBeSelected = deckBuilderInteractor.CanThisCardBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }
    }
}
