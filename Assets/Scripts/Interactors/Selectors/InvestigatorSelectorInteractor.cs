using Arkham.Repositories;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorSelectorInteractor : IInvestigatorSelectorInteractor
    {
        [Inject] private readonly IInvestigatorSelectorInfo investigatorSelectorInfo;
        [Inject] private readonly ICardInfo cardInfo;
        [Inject] private readonly IInvestigatorInfo investigatorRepository;
        [Inject] private readonly Settings settings;
        [Inject] private readonly IUnlockCardsInfo unlockCards;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string investigatorId)
        {
            if (investigatorSelectorInfo.IsSelectionFull) return false;
            if (investigatorRepository.Get(investigatorId).IsEliminated) return false;
            if (!unlockCards.IsThisCardUnlocked(investigatorId)) return false;
            if (IsThisInvestigatorWasted(investigatorId)) return false;
            return true;
        }

        public bool CanThisCardBeShowed(string investigatorId)
        {
            if (!cardInfo.ThisCardContainThisText(investigatorId, settings.TextToSearch)) return false;
            if (settings.AreCardsVisible) return true;
            if (unlockCards.IsThisCardUnlocked(investigatorId)) return true;
            return false;
        }

        private bool IsThisInvestigatorWasted(string investigatorId) =>
            cardInfo.Get(investigatorId).Quantity
            - investigatorSelectorInfo.AmountSelectedOfThisInvestigator(investigatorId) <= 0;
    }
}
