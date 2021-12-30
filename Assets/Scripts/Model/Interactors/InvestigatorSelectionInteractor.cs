using System.Collections.Generic;
using Zenject;

namespace Arkham.Model
{
    public class InvestigatorSelectionInteractor
    {
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
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
