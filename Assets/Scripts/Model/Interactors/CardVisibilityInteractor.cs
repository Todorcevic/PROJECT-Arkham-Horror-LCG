using Zenject;

namespace Arkham.Model
{
    public class CardVisibilityInteractor
    {
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;
        [Inject] private readonly ICardSearchable cardSearch;
        [Inject] private readonly IVisibility visibility;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;

        /*******************************************************************/
        public bool CanThisCardBeShowed(string cardId, string investigatorId)
        {
            Card card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);

            if (!card.ContainThisText(cardSearch.TextToSearch)) return false;
            if (visibility.IsOn) return true;
            if (cardSelectionFilter.IsThisCardAllowed(card, investigator) && unlockCardsRepository.IsThisCardUnlocked(card)) return true;
            return false;
        }
    }
}
