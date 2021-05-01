using Arkham.Model;
using Zenject;

namespace Arkham.Model
{
    public class InvestigatorState
    {
        [Inject] private readonly Settings settings;
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

        public bool CanThisCardBeShowed(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);

            if (!investigator.Info.ContainThisText(settings.TextToSearch)) return false;
            if (settings.AreCardsVisible) return true;
            if (unlockCardsRepository.IsThisCardUnlocked(investigator.Info)) return true;
            return false;
        }

        private bool IsThisInvestigatorWasted(Investigator investigator) =>
            investigator.Info.Quantity - selectorRepository.AmountSelectedOfThisInvestigator(investigator) <= 0;
    }
}
