﻿using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class AddCardUseCase
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly CardShowerPresenter cardShowerPresenter;
        [Inject] private readonly UpdateXpUseCase updateXpUseCase;

        /*******************************************************************/
        public void AddCard(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            updateXpUseCase.PayCardXp(investigator, card);
            UpdateModel(card, investigator);
            UpdateView(card, investigator);
        }

        private void UpdateModel(Card card, Investigator investigator) => investigator.AddToDeck(card);

        private void UpdateView(Card card, Investigator investigator)
        {
            cardShowerPresenter.MoveCard();
            cardSelector.SetCardInSelector(card, investigator);
            cardSelector.SetCanBeRemovedInSelectors(investigator.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(card);
            cardQuantity.Refresh(investigator);
            readyButton.AutoActivate();
        }
    }
}
