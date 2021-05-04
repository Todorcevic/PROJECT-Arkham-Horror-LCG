using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.Adapter
{
    public class RemoveCardUseCase
    {
        [Inject] private readonly ReadyButtonController readyButton;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly CardShowerPresenter cardShower;
        [Inject] private readonly CardsQuantityPresenter cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardselector;
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardRepository cardRepository;

        /*******************************************************************/
        public void ExecuteWith(string cardId)
        {
            Card card = cardRepository.Get(cardId);
            if (UpdateModel(card)) UpdateView(card);
            else CantRemoveAnimation(card.Code);
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
            cardselector.SetCardInSelector(new CardRowDTO(card.Code, card.Real_name, currentQuantity));
            cardShower.RemoveCardAnimation();
            cardVisibility.RefreshCardsVisibility();
            cardQuantity.Refresh();
            readyButton.Desactive(!selector.IsReady);
        }

        private void CantRemoveAnimation(string cardId) => cardselector.CantRemove(cardId);
    }
}
