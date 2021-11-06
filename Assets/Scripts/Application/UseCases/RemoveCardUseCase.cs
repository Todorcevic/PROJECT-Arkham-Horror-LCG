﻿using Arkham.Model;
using Arkham.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class RemoveCardUseCase
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CardsQuantityView cardQuantity;
        [Inject] private readonly CardSelectorPresenter cardSelector;
        [Inject] private readonly MultiAnimator multiAnimator;
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
            cardSelector.SetCardInSelector(card, investigator);
            cardSelector.SetCanBeRemovedInSelectors(investigator.Id);
            multiAnimator.RemoveCard(card.Id);
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.SetQuantity(card);
            cardQuantity.Refresh(investigator);
            readyButton.AutoActivate();
            cardsButton.ExecuteClick();
        }
    }
}
