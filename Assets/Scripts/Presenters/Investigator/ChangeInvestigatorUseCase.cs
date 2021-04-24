using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class ChangeInvestigatorUseCase : IInitializable
    {
        [Inject] private readonly IChangeInvestigatorEvent changeInvestigatorEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly ILeadInvestigatorUseCase selectorLead;

        /*******************************************************************/
        public void Initialize() => changeInvestigatorEvent.AddAction(ChangeInvestigator);

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
