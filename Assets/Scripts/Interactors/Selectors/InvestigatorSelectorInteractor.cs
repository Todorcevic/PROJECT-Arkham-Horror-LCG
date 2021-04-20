using Arkham.Config;
using Arkham.Repositories;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorSelectorInteractor : IInvestigatorSelectorInteractor
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly ISettings settings;
        [Inject] private readonly IUnlockCards unlockCards;

        public string LeadInvestigator => investigatorSelectorRepository.InvestigatorsSelectedList.FirstOrDefault();
        public int AmontInvestigatorsSelected => investigatorSelectorRepository.InvestigatorsSelectedList.Count;
        public bool SelectionIsFull => AmontInvestigatorsSelected >= GameConfig.MAX_INVESTIGATORS;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId)
        {
            if (SelectionIsFull) return false;
            if (!unlockCards.IsThisCardUnlocked(cardId)) return false;
            if (IsThisInvestigatorWasted(cardId)) return false;
            return true;
        }

        public bool CanThisCardBeShowed(string cardId)
        {
            if (!cardInfoInteractor.ThisCardContainThisText(cardId, settings.TextToSearch)) return false;
            if (settings.AreCardsVisible) return true;
            if (unlockCards.IsThisCardUnlocked(cardId)) return true;
            return false;
        }

        private int AmountSelectedOfThisInvestigator(string investigatorId) =>
            investigatorSelectorRepository.InvestigatorsSelectedList.FindAll(i => i == investigatorId).Count;

        private bool IsThisInvestigatorWasted(string investigatorId) =>
            cardInfoInteractor.GetQuantity(investigatorId) - AmountSelectedOfThisInvestigator(investigatorId) <= 0;
    }
}
