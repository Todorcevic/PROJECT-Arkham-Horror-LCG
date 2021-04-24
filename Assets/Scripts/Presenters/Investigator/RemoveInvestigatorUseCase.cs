using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class RemoveInvestigatorUseCase : IInitializable
    {
        [Inject] private readonly IRemoveInvestigatorEvent removeInvestigatorEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly ILeadInvestigatorUseCase selectorLead;

        /*******************************************************************/
        public void Initialize() => removeInvestigatorEvent.AddAction(RemoveInvestigator);

        /*******************************************************************/
        private void RemoveInvestigator(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelectorsManager.GetSelectorById(investigatorId);
            selector.SetTransform();
            selector.EmptySelector();
            selectorLead.SetLeadSelector();
            Animation(selector);
        }

        private async void Animation(InvestigatorSelectorView selector)
        {
            investigatorSelectorsManager.RebuildPlaceHolders();
            investigatorSelectorsManager.ArrangeAllSelectors();
            await selector.RemoveAnimation();
        }
    }
}
