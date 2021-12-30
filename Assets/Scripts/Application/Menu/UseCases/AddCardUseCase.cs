using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class AddCardUseCase
    {
        [Inject] private readonly CardsRepository cardsRepository;
        [Inject] private readonly InvestigatorsRepository investigatorsRepository;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly UpdateXpUseCase updateXpUseCase;
        [Inject] private readonly CardShowerPresenter multiAnimator;
        [Inject] private readonly NameConventionFactoryService factory;

        /*******************************************************************/
        public void AddCard(string cardId, string investigatorId)
        {
            CardInfo card = cardsRepository.Get(cardId);
            Investigator investigator = investigatorsRepository.Get(investigatorId);
            updateXpUseCase.PayCardXp(investigator, card);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        private void UpdateModel(CardInfo card, Investigator investigator) => investigator.AddToDeck(card);

        private void UpdateView(CardInfo card, Investigator investigator)
        {
            CardSelectorView selector = cardSelector.SetCardInSelector(card, investigator);
            multiAnimator.AddCard(selector, card.Id);
            cardSelector.SetCanBeRemovedInSelectors(investigator.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(card);
            cardQuantity.Refresh(investigator);
            multiAnimator.ReshowCardDeck(card.Id);
            readyButton.AutoActivate();
        }
    }
}
