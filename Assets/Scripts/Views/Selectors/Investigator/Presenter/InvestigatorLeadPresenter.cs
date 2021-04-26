using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorLeadPresenter : IInvestigatorLeadPresenter
    {
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorSelectorInfo investigatorSelectorInfo;

        private InvestigatorSelectorView LeadSelector => investigatorSelectorsManager.GetLeadSelector;

        /*******************************************************************/
        public void SetLeadSelector()
        {
            if (investigatorSelectorInfo.Lead == LeadSelector?.Id
                || investigatorSelectorInfo.Lead == null) return;
            LeadSelector?.LeadIcon(false);
            investigatorSelectorsManager.GetSelectorById(investigatorSelectorInfo.Lead).LeadIcon(true);
        }
    }
}
