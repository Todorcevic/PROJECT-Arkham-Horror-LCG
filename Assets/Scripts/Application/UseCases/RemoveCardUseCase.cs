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
        [Inject] private readonly SelectorSelectionInteractor selectorSelectionInteractor;

        /*******************************************************************/
        public void Remove(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        //private bool CanRemoveCard(Card card, Investigator investigator)
        //{
        //    if (investigator.IsMandatoryCard(card)) return false;
        //    if (investigator.IsPlaying && investigator.Xp <= 0) return false;
        //    if (investigator.IsPlaying && !investigator.SelectionIsFull) return false;
        //    return true;
        //}

        private void UpdateModel(Card card, Investigator investigator) => investigator.RemoveToDeck(card);

        private void UpdateView(Card card, Investigator investigator)
        {
            cardSelector.SetCardInSelector(CreateCardRowDTO(card, investigator));
            cardSelector.RefreshBackgroundColor(investigator.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(new CardQuantityDTO(card.Id, investigatorRepository.AmountLeftOfThisCard(card)));
            cardQuantity.Refresh(investigator?.AmountCardsSelected.ToString(), investigator?.DeckBuilding.DeckSize.ToString());
            readyButton.Desactive(!selector.IsReady);
        }

        private CardRowDTO CreateCardRowDTO(Card card, Investigator investigator) =>
            new CardRowDTO(card.Id, card.Real_name, investigator.GetAmountOfThisCardInDeck(card));
    }
}
