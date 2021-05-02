using Arkham.Model;
using Zenject;

namespace Arkham.Services
{
    public class CardVisibilityService
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly ICardSearch cardSearch;
        [Inject] private readonly IVisibility visibility;
        [Inject] private readonly CardSelectionFiler cardSelectionFilter;

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
