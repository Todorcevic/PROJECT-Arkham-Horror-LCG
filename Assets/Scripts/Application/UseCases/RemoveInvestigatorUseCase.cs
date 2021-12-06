using Arkham.Model;
using Arkham.Application;
using Zenject;

namespace Arkham.Application
{
    public class RemoveInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly SelectorRepository selectorRepository;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;

        /*******************************************************************/
        public void Remove(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            if (!selectorRepository.Contains(investigator)) return;
            UpdateModel(investigator);
            UpdateView(investigatorId);
            selectInvestigatorUseCase.SelectLead();
        }

        private void UpdateModel(Investigator investigator) => selectorRepository.Remove(investigator);

        private void UpdateView(string investigatorId)
        {
            investigatorVisibility.RefreshInvestigatorsSelectability();
            investigatorSelector.SetLeadSelector();
            investigatorSelector.RemoveInvestigator(investigatorId);     
            readyButton.AutoActivate();
            investigatorsButton.ExecuteClick();
        }
    }
}
