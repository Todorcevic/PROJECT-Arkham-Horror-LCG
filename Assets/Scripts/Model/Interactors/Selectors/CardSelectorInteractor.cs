﻿using Arkham.Config;
using Zenject;

namespace Arkham.Model
{
    public class CardSelectorInteractor
    {
        [Inject] private readonly InvestigatorInfoRepository investigatorInfo;
        [Inject] private readonly CardInfoRepository cardInfo;
        [Inject] private readonly CurrentInvestigatorInteractor currentInvestigator;
        [Inject] private readonly Settings settings;
        [Inject] private readonly UnlockCardRepository unlockCardInfo;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId)
        {
            if (currentInvestigator?.Info?.Id == null) return false;
            if (currentInvestigator.Info.SelectionIsFull) return false;
            if (!unlockCardInfo.IsThisCardUnlocked(cardId)) return false;
            if (!IsThisCardAllowed(cardId)) return false;
            if (IsThisCardWasted(cardId)) return false;
            if (IsThisCardInMax(cardId)) return false;
            return true;
        }

        public bool CanThisCardBeShowed(string cardId)
        {
            if (!cardInfo.ThisCardContainThisText(cardId, settings.TextToSearch)) return false;
            if (settings.AreCardsVisible) return true;
            if (IsThisCardAllowed(cardId) && unlockCardInfo.IsThisCardUnlocked(cardId)) return true;
            return false;
        }

        private bool IsThisCardAllowed(string cardId)
        {
            if (currentInvestigator.Info?.Id == null) return false;
            if (!currentInvestigator.Info.DeckBuilding.AllowedCards().Contains(cardId)) return false;
            if (currentInvestigator.Info?.Xp < cardInfo.Get(cardId).Xp) return false;
            return true;
        }

        private bool IsThisCardWasted(string cardId) =>
            cardInfo.Get(cardId).Quantity - investigatorInfo.AmountSelectedOfThisCard(cardId) <= 0;

        private bool IsThisCardInMax(string cardId) =>
            currentInvestigator.Info.GetAmountOfThisCardInDeck(cardId) >= GameConfig.MAX_SIMILARS_CARDS_IN_DECK;
    }
}