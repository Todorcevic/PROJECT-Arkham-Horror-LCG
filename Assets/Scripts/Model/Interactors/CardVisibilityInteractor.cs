using Zenject;

namespace Arkham.Model
{
    public class CardVisibilityInteractor
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly ICardSearchable cardSearch;
        [Inject] private readonly IVisibility visibility;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;

        /*******************************************************************/
        public bool CanThisCardBeShowed(string cardId)
        {
            Card card = cardRepository.Get(cardId);
            if (!card.ContainThisText(cardSearch.TextToSearch)) return false;
            if (visibility.IsOn) return true;
            if (cardSelectionFilter.IsThisCardAllowed(card) && unlockCardsRepository.IsThisCardUnlocked(card)) return true;
            return false;
        }
    }
}
