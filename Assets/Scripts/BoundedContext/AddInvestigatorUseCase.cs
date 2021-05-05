using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.UseCases
{
    public class AddInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly InvestigatorSelectionInteractor investigatorSelectionFilter;
        [Inject] private readonly Selector selector;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Add(string investigatorId)
        {
            UpdateModel(investigatorId);
            UpdateView(investigatorId);
        }

        private void UpdateModel(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            selector.Add(investigator);
        }

        private void UpdateView(string investigatorId)
        {
            investigatorSelector.AddInvestigator(investigatorId);
            investigatorSelector.SetLeadSelector(selector.Lead?.Id);
            investigatorVisibility.RefreshInvestigatorsSelectability();
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
