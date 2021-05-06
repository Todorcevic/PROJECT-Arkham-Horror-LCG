using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class RemoveCardUseCase
    {
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardSelector;

        /*******************************************************************/
        public bool ExecuteWith(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            bool isRemoved = UpdateModel(card, investigator);
            if (isRemoved) UpdateView(card, investigator);
            return isRemoved;
        }

        private bool UpdateModel(Card card, Investigator investigator)
        {
            if (investigator.IsMandatoryCard(card)) return false;
            investigator.RemoveToDeck(card);
            return true;
        }

        private void UpdateView(Card card, Investigator investigator)
        {
            int currentQuantity = investigator.GetAmountOfThisCardInDeck(card);
            cardSelector.SetCardInSelector(new CardRowDTO(card.Id, card.Real_name, currentQuantity));
            cardVisibility.RefreshCardsSelectability();
            string amountCards = investigator?.AmountCardsSelected.ToString();
            string deckSize = investigator?.DeckBuilding.DeckSize.ToString();
            cardQuantity.Refresh(amountCards, deckSize);
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
