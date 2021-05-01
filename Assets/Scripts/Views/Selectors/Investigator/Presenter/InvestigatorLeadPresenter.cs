using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorLeadPresenter : IInvestigatorLeadPresenter
    {
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly Selector selector;

        private InvestigatorSelectorView LeadSelector => investigatorSelectorsManager.GetLeadSelector;

        /*******************************************************************/
        public void SetLeadSelector()
        {
            if (selector.Lead == null || selector.Lead.Id == LeadSelector?.Id) return;
            LeadSelector?.LeadIcon(false);
            investigatorSelectorsManager.GetSelectorById(selector.Lead.Id).LeadIcon(true);
        }
    }
}
