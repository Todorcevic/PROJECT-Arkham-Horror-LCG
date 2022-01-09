using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RemoveCardUseCase
    {
        [Inject] private readonly CardsRepository cardRepository;
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardSelectorPresenter;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;

        /*******************************************************************/
        public void Remove(string cardId, string investigatorId)
        {
            CardInfo card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        private void UpdateModel(CardInfo card, Investigator investigator) => investigator.RemoveToDeck(card);

        private void UpdateView(CardInfo card, Investigator investigator)
        {
            cardShowerPresenter.RemoveCard(card.Id);
            cardSelectorPresenter.SetCardInSelector(card, investigator);
            cardSelectorPresenter.SetCanBeRemovedInSelectors(investigator.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(card);
            cardQuantity.Refresh(investigator);
            cardShowerPresenter.ReshowCardSelector(card.Id);
            buttonsPresenter.AutoActivateReadyButton();
            buttonsPresenter.ExecuteCardsButton();
        }
    }
}
