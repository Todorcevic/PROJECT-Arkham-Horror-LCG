using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class AddInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly ReadyButtonPresenter readyButton;
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
            investigatorSelector.SetLeadSelector();
            investigatorVisibility.RefreshInvestigatorsSelectability();
            readyButton.AutoActivate();
        }
    }
}
