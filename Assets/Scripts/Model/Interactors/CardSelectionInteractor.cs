using Arkham.Config;
using Zenject;

namespace Arkham.Model
{
    public class CardSelectionInteractor
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);

            if (investigator == null) return false;
            if (investigator.SelectionIsFull) return false;
            if (!unlockCardsRepository.IsThisCardUnlocked(card)) return false;
            if (!IsThisCardAllowed(card, investigator)) return false;
            if (IsThisCardWasted(card)) return false;
            if (IsThisCardInMax(card, investigator)) return false;
            return true;
        }

        public bool IsThisCardAllowed(Card card, Investigator investigator)
        {
            if (card.IsInvestigator) return true;
            if (investigator == null) return false;
            if (!investigator.DeckBuilding.AllowedCards.Contains(card)) return false;
            if (investigator.Xp < card.Xp) return false;
            return true;
        }

        private bool IsThisCardWasted(Card card) =>
            card.Quantity - investigatorRepository.AmountSelectedOfThisCard(card) <= 0;

        private bool IsThisCardInMax(Card card, Investigator investigator) =>
            investigator.GetAmountOfThisCardInDeck(card) >= GameConfig.MAX_SIMILARS_CARDS_IN_DECK;
    }
}