using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class AddCardUseCase
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        /*******************************************************************/
        public void AddCard(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        private void UpdateModel(Card card, Investigator investigator) => investigator.AddToDeck(card);

        private void UpdateView(Card card, Investigator investigator)
        {
            int quantity = investigator.GetAmountOfThisCardInDeck(card);
            cardSelector.SetCardInSelector(new CardRowDTO(card.Id, card.Real_name, quantity));
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(new CardQuantityDTO(card.Id, investigatorRepository.AmountLeftOfThisCard(card)));
            string amountCards = investigator?.AmountCardsSelected.ToString();
            string deckSize = investigator?.DeckBuilding.DeckSize.ToString();
            cardQuantity.Refresh(amountCards, deckSize);
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
