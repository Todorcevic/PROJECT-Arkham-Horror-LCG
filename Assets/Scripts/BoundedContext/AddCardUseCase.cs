using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.UseCases
{
    public class AddCardUseCase
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardSelectorPresenter cardAdd;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;

        private string AmountCards => selector.InvestigatorSelected?.AmountCardsSelected.ToString();
        private string DeckSize => selector.InvestigatorSelected?.DeckBuilding.DeckSize.ToString();

        /*******************************************************************/
        public void AddCard(string cardId)
        {
            Card card = cardRepository.Get(cardId);
            UpdateModel(card);
            UpdateView(card);
        }

        private void UpdateModel(Card card) => selector.InvestigatorSelected.AddToDeck(card);

        private void UpdateView(Card card)
        {
            int quantity = selector.InvestigatorSelected.GetAmountOfThisCardInDeck(card);
            cardAdd.SetCardInSelector(new CardRowDTO(card.Id, card.Real_name, quantity));
            cardVisibility.RefreshCardsSelectability();
            cardQuantity.Refresh(AmountCards, DeckSize);
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
