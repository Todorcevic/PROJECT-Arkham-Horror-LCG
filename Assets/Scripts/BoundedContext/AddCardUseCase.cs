using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.Adapter
{
    public class AddCardUseCase
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardShowerPresenter cardShower;
        [Inject] private readonly CardSelectorPresenter cardAdd;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly CardsQuantityPresenter cardQuantity;
        [Inject] private readonly ReadyButtonController readyButton;

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
            cardShower.AddCardAnimation();
            cardAdd.SetCardInSelector(new CardRowDTO(card.Code, card.Real_name, quantity));
            cardVisibility.RefreshCardsVisibility();
            cardQuantity.Refresh();
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
