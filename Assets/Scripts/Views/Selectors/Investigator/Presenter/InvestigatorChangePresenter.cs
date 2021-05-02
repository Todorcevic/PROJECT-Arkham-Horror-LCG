using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class InvestigatorChangePresenter : IInitializable
    {
        [Inject] private readonly ChangeInvestigatorEventDomain investigatorChangeEvent;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly InvestigatorLeadPresenter selectorLead;

        /*******************************************************************/
        public void Initialize() => investigatorChangeEvent.Subscribe(ChangeInvestigator);

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
