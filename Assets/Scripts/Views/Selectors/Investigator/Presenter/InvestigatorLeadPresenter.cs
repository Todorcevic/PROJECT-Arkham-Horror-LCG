using Arkham.Interactors;

using Zenject;

namespace Arkham.Views
{
    public class InvestigatorLeadPresenter : IInvestigatorLeadPresenter
    {
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        private string LeadInvestigator => investigatorSelectorInteractor.LeadInvestigator;
        private InvestigatorSelectorView LeadSelector => investigatorSelectorsManager.GetLeadSelector;

        /*******************************************************************/
        public void SetLeadSelector()
        {
            if (LeadInvestigator == LeadSelector?.Id || LeadInvestigator == null) return;
            LeadSelector?.LeadIcon(false);
            investigatorSelectorsManager.GetSelectorById(LeadInvestigator).LeadIcon(true);
        }
    }
}
