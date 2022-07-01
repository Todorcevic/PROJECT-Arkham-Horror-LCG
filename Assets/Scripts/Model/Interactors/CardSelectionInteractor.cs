using Zenject;

namespace Arkham.Model
{
    public class CardSelectionInteractor
    {
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly CardsInfoRepository cardRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId, string investigatorId)
        {
            CardInfo card = cardRepository.GetInfo(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);

            if (investigator == null) return false;
            if (investigator.IsEliminated) return false;
            if (investigator.SelectionIsFull) return false;
            if (!unlockCardsRepository.IsThisCardUnlocked(card)) return false;
            if (!IsThisCardAllowed(card, investigator)) return false;
            if (IsThisCardWasted(card)) return false;
            if (IsThisCardInMax(card, investigator)) return false;
            return true;
        }

        public bool IsThisCardAllowed(CardInfo card, Investigator investigator)
        {
            if (card.IsInvestigator) return true;
            if (investigator == null) return false;
            if (!investigator.DeckBuilding.AllowedCards.Contains(card)) return false;
            if (investigator.Xp < card.Xp) return false;
            return true;
        }

        private bool IsThisCardWasted(CardInfo card) =>
            card.Quantity - investigatorRepository.AmountSelectedOfThisCard(card) <= 0;

        private bool IsThisCardInMax(CardInfo card, Investigator investigator) =>
            investigator.GetAmountOfThisCardInDeck(card) >= GameValues.MAX_SIMILARS_CARDS_IN_DECK;
    }
}