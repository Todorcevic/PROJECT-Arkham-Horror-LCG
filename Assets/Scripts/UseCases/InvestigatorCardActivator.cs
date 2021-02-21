using Arkham.Presenters;
using Arkham.Repositories;
using System.Linq;
using Zenject;

namespace Arkham.UseCases
{
    public class InvestigatorCardActivator : IInvestigatorCardActivator
    {
        [Inject] private readonly ICardInfoRepository cardInfo;
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly IInvestigatorsSelectedRepository selectorRepository;
        [Inject] private readonly ICardPresenter cardPresenter;
        private bool SelectionIsFull => selectorRepository.InvestigatorsSelectedList.Count >= GameData.MAX_INVESTIGATORS;

        /*******************************************************************/
        public void ActivateCard(string cardId) => cardPresenter.EnableCard(cardId, CheckIsEnable(cardId));

        public void RefreshAllCards()
        {
            foreach (string investigatorCard in investigatorRepository.InvestigatorsList.Select(i => i.Id))
                ActivateCard(investigatorCard);
        }

        private bool CheckIsEnable(string cardId)
        {
            if (SelectionIsFull) return false;
            if (((cardInfo.AllCardsInfo(cardId).Quantity ?? 0) - AmountCardsSelected(cardId)) <= 0) return false;
            return true;
        }

        private int AmountCardsSelected(string cardId) =>
            selectorRepository.InvestigatorsSelectedList.FindAll(i => i == cardId).Count;
    }
}
