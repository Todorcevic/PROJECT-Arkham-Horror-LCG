using Arkham.Config;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Interactors
{
    public class CardSelectorInteractor : ICardSelectorInteractors
    {
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;
        [Inject] private readonly ISettings settings;
        [Inject] private readonly IUnlockCards unlockCards;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId)
        {
            if (currentInvestigator.Id == null) return false;
            if (currentInvestigator.SelectionIsFull) return false;
            if (!unlockCards.IsThisCardUnlocked(cardId)) return false;
            if (!IsThisCardAllowed(cardId)) return false;
            if (IsThisCardWasted(cardId)) return false;
            if (IsThisCardInMax(cardId)) return false;
            return true;
        }

        public bool CanThisCardBeShowed(string cardId)
        {
            if (!cardInfoInteractor.ThisCardContainThisText(cardId, settings.TextToSearch)) return false;
            if (settings.AreCardsVisible) return true;
            if (IsThisCardAllowed(cardId) && unlockCards.IsThisCardUnlocked(cardId)) return true;
            return false;
        }

        private bool IsThisCardAllowed(string cardId)
        {
            if (currentInvestigator.Id == null) return false;
            if (!currentInvestigator.AllowedCards.Contains(cardId)) return false;
            if (currentInvestigator.Xp < cardInfoInteractor.GetXp(cardId)) return false;
            return true;
        }

        private bool IsThisCardWasted(string cardId) =>
            cardInfoInteractor.GetQuantity(cardId) - investigatorInfoInteractor.AmountSelectedOfThisCard(cardId) <= 0;

        private bool IsThisCardInMax(string cardId) =>
            currentInvestigator.GetAmountOfThisCardInDeck(cardId) >= GameConfig.MAX_SIMILARS_CARDS_IN_DECK;
    }
}