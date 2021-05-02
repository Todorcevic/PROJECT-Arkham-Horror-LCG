using Zenject;

namespace Arkham.Model
{
    public class InvestigatorSelectionFilter
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly UnlockCardsRepository unlockCardsRepository;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);

            if (selectorRepository.IsSelectionFull) return false;
            if (investigator.IsEliminated) return false;
            if (!unlockCardsRepository.IsThisCardUnlocked(investigator.Info)) return false;
            if (IsThisInvestigatorWasted(investigator)) return false;
            return true;
        }

        private bool IsThisInvestigatorWasted(Investigator investigator) =>
            investigator.Info.Quantity - selectorRepository.AmountSelectedOfThisInvestigator(investigator) <= 0;
    }
}
