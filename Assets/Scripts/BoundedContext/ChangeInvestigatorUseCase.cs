using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.UseCases
{
    public class ChangeInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Swap(int positionToSwap, string investigatorId)
        {
            string investigatorFromSwap = UpdateModel(positionToSwap, investigatorId);
            UpdateView(investigatorId, investigatorFromSwap);
        }

        private string UpdateModel(int positionToSwap, string investigatorId)
        {
            Investigator investigatorToSwap = investigatorRepository.Get(investigatorId);
            Investigator investigatorFromSwap = selector.Swap(positionToSwap, investigatorToSwap);
            return investigatorFromSwap.Id;
        }

        private void UpdateView(string investigatorId1, string investigatorId2)
        {
            investigatorSelector.ChangeInvestigator(investigatorId1, investigatorId2);
            investigatorSelector.SetLeadSelector(selector.Lead?.Id);
        }
    }
}
