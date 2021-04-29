using Zenject;

namespace Arkham.Model
{
    public class InvestigatorSelectorInteractor
    {
        [Inject] private readonly Settings settings;
        [Inject] private readonly InvestigatorSelectorRepository investigatorSelectorInfo;
        [Inject] private readonly CardInfoRepository cardInfo;
        [Inject] private readonly InvestigatorInfoRepository investigatorInfo;
        [Inject] private readonly UnlockCardRepository unlockCardInfo;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string investigatorId)
        {
            if (investigatorSelectorInfo.IsSelectionFull) return false;
            if (investigatorInfo.Get(investigatorId).IsEliminated) return false;
            if (!unlockCardInfo.IsThisCardUnlocked(investigatorId)) return false;
            if (IsThisInvestigatorWasted(investigatorId)) return false;
            return true;
        }

        public bool CanThisCardBeShowed(string investigatorId)
        {
            if (!cardInfo.ThisCardContainThisText(investigatorId, settings.TextToSearch)) return false;
            if (settings.AreCardsVisible) return true;
            if (unlockCardInfo.IsThisCardUnlocked(investigatorId)) return true;
            return false;
        }

        private bool IsThisInvestigatorWasted(string investigatorId) =>
            cardInfo.Get(investigatorId).Quantity
            - investigatorSelectorInfo.AmountSelectedOfThisInvestigator(investigatorId) <= 0;
    }
}
