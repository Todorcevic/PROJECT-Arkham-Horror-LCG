using Zenject;

namespace Arkham.Model
{
    public class CardXpCostInteractor
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;

        /*******************************************************************/
        public int XpPayCost(string cardId, string investigatorId)
        {
            CardInfo card = cardRepository.Get(cardId);
            Investigator investigator = investigatorRepository.Get(investigatorId);
            bool canBeSelected = cardSelectionFilter.CanThisCardBeSelected(cardId, investigatorId);

            if (!canBeSelected) return 0;
            if (!investigator.IsPlaying) return 0;
            if (investigator.LastCardRemoved == card) return 0;
            return (card.Xp ?? 0) == 0 ? 1 : (card.Xp ?? 0);
        }
    }
}
