using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class SelectorInitPresenter
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly AddInvestigatorPresenter selectorAdd;
        [Inject] private readonly InvestigatorLeadPresenter selectorLead;

        /*******************************************************************/
        public void InitializeSelectors()
        {
            investigatorSelectorsManager.ResetSelectors();
            AddAllInvestigators();
            SelectLeadInvestigator();
        }

        private void AddAllInvestigators()
        {
            foreach (string investigatorId in selectorRepository.Ids)
                selectorAdd.InitInvestigator(investigatorId);
        }

        private void SelectLeadInvestigator()
        {
            selectorLead.SetLeadSelector();
            investigatorSelectEvent.SelectCurrentOrLead();
        }
    }
}
