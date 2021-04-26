using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorChangePresenter : IInitializable
    {
        [Inject] private readonly IInvestigatorChangedEvent changeInvestigatorEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorLeadPresenter selectorLead;

        /*******************************************************************/
        public void Initialize() => changeInvestigatorEvent.Subscribe(ChangeInvestigator);

        /*******************************************************************/
        private void ChangeInvestigator(string investigatorId1, string investigatorId2)
        {
            InvestigatorSelectorView selector1 = investigatorSelectorsManager.GetSelectorById(investigatorId1);
            InvestigatorSelectorView selector2 = investigatorSelectorsManager.GetSelectorById(investigatorId2);
            selector1.SwapPlaceHoldersWith(selector2);
            selectorLead.SetLeadSelector();
            Animation(selector1);
        }

        private void Animation(InvestigatorSelectorView selector)
        {
            investigatorSelectorsManager.RebuildPlaceHolders();
            selector.ArrangeAnimation();
        }
    }
}
