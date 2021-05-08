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
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardSelector;

        /*******************************************************************/
        public bool Remove(string cardId, string investigatorId)
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
            cardSelector.SetCardInSelector(CreateCardRowDTO(card, investigator));
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(new CardQuantityDTO(card.Id, investigatorRepository.AmountLeftOfThisCard(card)));
            cardQuantity.Refresh(investigator?.AmountCardsSelected.ToString(), investigator?.DeckBuilding.DeckSize.ToString());
            readyButton.Desactive(!selector.IsReady);
        }

        private CardRowDTO CreateCardRowDTO(Card card, Investigator investigator) =>
            new CardRowDTO(card.Id, card.Real_name, investigator.GetAmountOfThisCardInDeck(card));
    }
}
