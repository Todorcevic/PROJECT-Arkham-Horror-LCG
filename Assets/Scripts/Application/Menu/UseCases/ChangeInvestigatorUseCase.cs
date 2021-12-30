using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ChangeInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Swap(int positionToSwap, string investigatorId)
        {
            Investigator investigatorToSwap = investigatorRepository.Get(investigatorId);
            string investigatorFromSwapId = UpdateModel(positionToSwap, investigatorToSwap);
            UpdateView(investigatorId, investigatorFromSwapId);
        }

        private string UpdateModel(int positionToSwap, Investigator investigatorToSwap) =>
            selectorRepository.Swap(positionToSwap, investigatorToSwap).Id;

        private void UpdateView(string investigatorToSwapId, string investigatorFromSwapId)
        {
            investigatorSelector.ChangeInvestigator(investigatorToSwapId, investigatorFromSwapId);
            investigatorSelector.SetLeadSelector();
        }
    }
}
