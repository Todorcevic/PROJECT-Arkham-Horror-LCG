using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class DeckCardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;
        [Inject] private readonly CardVisibilityInteractor visibilityService;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;

        /*******************************************************************/
        public void RefreshCardsVisibility()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Show(canBeShowed);
            }
        }

        public void RefreshCardsSelectability()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                bool canBeSelected = cardSelectionFilter.CanThisCardBeSelected(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Activate(canBeSelected);
            }
        }

        public void RefresQuantity()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                Card card = cardRepository.Get(cardView.Id);
                int quantity = investigatorRepository.AmountLeftOfThisCard(card);
                cardView.SetQuantity(FormatQuantity(quantity));
            }
        }

        public void SetQuantity(CardQuantityDTO cardQuantity) =>
            cardsManager.GetDeckCard(cardQuantity.CardId).SetQuantity(FormatQuantity(cardQuantity.Quantity));

        private string FormatQuantity(int quantity) => quantity > 1 ? "x" + quantity : string.Empty;
    }
}
