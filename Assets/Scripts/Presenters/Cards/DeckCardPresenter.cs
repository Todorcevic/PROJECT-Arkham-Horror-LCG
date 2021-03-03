using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Presenters
{
    public class DeckCardPresenter : IInitializable
    {
        [Inject] protected readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject] private readonly IDeckCardsManager deckCardsManager;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += RefreshAllCardsVisibility;
            deckBuilderInteractor.DeckCardAdded += ResolveAddVisibility;
            deckBuilderInteractor.DeckCardRemoved += ResolveRemoveVisibility;
        }

        /*******************************************************************/
        private void ResolveAddVisibility(string cardId)
        {
            if (deckBuilderInteractor.SelectionIsFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(cardId);
        }

        private void ResolveRemoveVisibility(string cardId)
        {
            if (deckBuilderInteractor.SelectionIsNotFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(cardId);
        }

        private void RefreshCardVisibility(string cardId)
        {
            bool canBeSelected = deckBuilderInteractor.CanBeSelected(cardId);
            deckCardsManager.AllCards[cardId].Activate(canBeSelected);
        }

        private void RefreshAllCardsVisibility(string _) => RefreshAllCardsVisibility();

        private void RefreshAllCardsVisibility()
        {
            foreach (ICardVisualizable cardView in deckCardsManager.CardsList)
            {
                bool canBeSelected = deckBuilderInteractor.CanBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }
    }
}
