﻿using Arkham.Config;
using Zenject;

namespace Arkham.Model
{
    public class CardState
    {
        [Inject] private readonly Settings settings;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId)
        {
            Card card = cardRepository.Get(cardId);

            if (selectorRepository.InvestigatorSelected == null) return false;
            if (selectorRepository.InvestigatorSelected.SelectionIsFull) return false;
            if (!unlockCardsRepository.IsThisCardUnlocked(card)) return false;
            if (!IsThisCardAllowed(card)) return false;
            if (IsThisCardWasted(card)) return false;
            if (IsThisCardInMax(card)) return false;
            return true;
        }

        public bool CanThisCardBeShowed(string cardId)
        {
            Card card = cardRepository.Get(cardId);

            if (!card.ContainThisText(settings.TextToSearch)) return false;
            if (settings.AreCardsVisible) return true;
            if (IsThisCardAllowed(card) && unlockCardsRepository.IsThisCardUnlocked(card)) return true;
            return false;
        }

        private bool IsThisCardAllowed(Card card)
        {
            if (selectorRepository.InvestigatorSelected == null) return false;
            if (!selectorRepository.InvestigatorSelected.DeckBuilder.AllowedCards.Contains(card)) return false;
            if (selectorRepository.InvestigatorSelected?.Xp < card.Xp) return false;
            return true;
        }

        private bool IsThisCardWasted(Card card) =>
            card.Quantity - investigatorRepository.AmountSelectedOfThisCard(card) <= 0;

        private bool IsThisCardInMax(Card card) =>
            selectorRepository.InvestigatorSelected.GetAmountOfThisCardInDeck(card.Code) >= GameConfig.MAX_SIMILARS_CARDS_IN_DECK;
    }
}