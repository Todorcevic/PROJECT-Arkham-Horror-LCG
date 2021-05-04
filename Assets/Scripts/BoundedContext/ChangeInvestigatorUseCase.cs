using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.Adapter
{
    public class ChangeInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly InvestigatorSelectorPresenter selectorInvestigator;

        /*******************************************************************/
        public void Swap(int positionToSwap, string investigatorId)
        {
            string investigatorFromSwap = UpdateModel(positionToSwap, investigatorId);
            UpdateView(investigatorId, investigatorFromSwap);
        }

        private string UpdateModel(int positionToSwap, string investigatorId)
        {
            Investigator investigatorToSwap = investigatorRepository.Get(investigatorId);
            Investigator investigatorFromSwap = selectorRepository.Swap(positionToSwap, investigatorToSwap);
            return investigatorFromSwap.Id;
        }

        private void UpdateView(string investigatorId1, string investigatorId2) =>
            selectorInvestigator.ChangeInvestigator(investigatorId1, investigatorId2);
    }
}
