using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class AddInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;

        /*******************************************************************/
        public void Add(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            UpdateModel(investigator);
            UpdateView(investigatorId);
        }

        private void UpdateModel(Investigator investigator) => selector.Add(investigator);

        private void UpdateView(string investigatorId)
        {
            investigatorSelector.AddInvestigator(investigatorId);
            investigatorSelector.SetLeadSelector(selector.Lead?.Id);
            investigatorVisibility.RefreshInvestigatorsSelectability();
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
