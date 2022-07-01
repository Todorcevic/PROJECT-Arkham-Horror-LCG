using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class AddCardUseCase
    {
        [Inject] private readonly CardsInfoRepository cardsRepository;
        [Inject] private readonly InvestigatorsRepository investigatorsRepository;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityPresenter cardQuantityPresenter;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;
        [Inject] private readonly UpdateXpUseCase updateXpUseCase;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;

        /*******************************************************************/
        public void AddCard(string cardId, string investigatorId)
        {
            CardInfo card = cardsRepository.GetInfo(cardId);
            Investigator investigator = investigatorsRepository.Get(investigatorId);
            updateXpUseCase.PayCardXp(investigator, card);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        private void UpdateModel(CardInfo card, Investigator investigator) => investigator.AddToDeck(card);

        private void UpdateView(CardInfo card, Investigator investigator)
        {
            CardSelectorView selector = cardSelector.SetCardInSelector(card, investigator);
            cardShowerPresenter.AddCard(selector, card.Id);
            cardSelector.SetCanBeRemovedInSelectors(investigator.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(card);
            cardQuantityPresenter.Update(investigator);
            cardShowerPresenter.ReshowCardDeck(card.Id);
            buttonsPresenter.AutoActivateReadyButton();
        }
    }
}
