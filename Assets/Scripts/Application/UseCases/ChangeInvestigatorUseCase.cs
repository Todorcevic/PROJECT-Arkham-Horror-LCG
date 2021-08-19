using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class ChangeInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Swap(int positionToSwap, string investigatorId)
        {
            Investigator investigatorToSwap = investigatorRepository.Get(investigatorId);
            string investigatorFromSwapId = UpdateModel(positionToSwap, investigatorToSwap);
            UpdateView(investigatorId, investigatorFromSwapId);
        }

        private string UpdateModel(int positionToSwap, Investigator investigatorToSwap) =>
            selector.Swap(positionToSwap, investigatorToSwap).Id;

        private void UpdateView(string investigatorToSwapId, string investigatorFromSwapId)
        {
            investigatorSelector.ChangeInvestigator(investigatorToSwapId, investigatorFromSwapId);
            investigatorSelector.SetLeadSelector(selector.Lead?.Id);
        }
    }
}
