using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.UseCases
{
    public class RemoveCardUseCase
    {
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardRepository cardRepository;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardSelector;

        private string AmountCards => selector.InvestigatorSelected?.AmountCardsSelected.ToString();
        private string DeckSize => selector.InvestigatorSelected?.DeckBuilding.DeckSize.ToString();

        /*******************************************************************/
        public bool ExecuteWith(string cardId)
        {
            Card card = cardRepository.Get(cardId);
            bool isRemoved = UpdateModel(card);
            if (isRemoved) UpdateView(card);
            return isRemoved;
        }

        private bool UpdateModel(Card card)
        {
            if (selector.InvestigatorSelected.IsMandatoryCard(card)) return false;
            selector.InvestigatorSelected.RemoveToDeck(card);
            return true;
        }

        private void UpdateView(Card card)
        {
            int currentQuantity = selector.InvestigatorSelected.GetAmountOfThisCardInDeck(card);
            cardSelector.SetCardInSelector(new CardRowDTO(card.Id, card.Real_name, currentQuantity));
            cardVisibility.RefreshCardsSelectability();
            cardQuantity.Refresh(AmountCards, DeckSize);
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
