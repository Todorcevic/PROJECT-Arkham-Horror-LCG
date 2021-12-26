using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RemoveCardUseCase
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardSelectorPresenter;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;

        /*******************************************************************/
        public void Remove(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        private void UpdateModel(Card card, Investigator investigator) => investigator.RemoveToDeck(card);

        private void UpdateView(Card card, Investigator investigator)
        {
            cardShowerPresenter.RemoveCard(card.Id);
            cardSelectorPresenter.SetCardInSelector(card, investigator);
            cardSelectorPresenter.SetCanBeRemovedInSelectors(investigator.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(card);
            cardQuantity.Refresh(investigator);
            cardShowerPresenter.ReshowCardSelector(card.Id);
            readyButton.AutoActivate();
            cardsButton.ExecuteClick();
        }
    }
}
