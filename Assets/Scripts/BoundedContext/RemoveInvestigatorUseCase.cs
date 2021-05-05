using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.UseCases
{
    public class RemoveInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly InvestigatorSelectionInteractor investigatorSelectionFilter;
        [Inject] private readonly Selector selector;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Remove(string investigatorId)
        {
            UpdateModel(investigatorId);
            UpdateView(investigatorId);
        }

        private void UpdateModel(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            selector.Remove(investigator);
        }

        private void UpdateView(string investigatorId)
        {
            investigatorVisibility.RefreshInvestigatorsSelectability();
            investigatorSelector.RemoveInvestigator(investigatorId);
            investigatorSelector.SetLeadSelector(selector.Lead?.Id);
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
