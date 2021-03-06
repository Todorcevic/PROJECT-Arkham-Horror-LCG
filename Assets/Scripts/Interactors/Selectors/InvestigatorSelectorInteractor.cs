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

        public string LeadInvestigator => investigatorSelectorRepository.InvestigatorsSelectedList.FirstOrDefault();
        public bool SelectionIsFull => investigatorSelectorRepository.InvestigatorsSelectedList.Count >= GameData.MAX_INVESTIGATORS;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId)
        {
            if (SelectionIsFull) return false;
            if (IsThisInvestigatorWasted(cardId)) return false;
            return true;
        }

        private int AmountSelectedOfThisInvestigator(string investigatorId) =>
            investigatorSelectorRepository.InvestigatorsSelectedList.FindAll(i => i == investigatorId).Count;

        private bool IsThisInvestigatorWasted(string investigatorId) =>
            cardInfoInteractor.GetQuantity(investigatorId) - AmountSelectedOfThisInvestigator(investigatorId) <= 0;
    }
}
