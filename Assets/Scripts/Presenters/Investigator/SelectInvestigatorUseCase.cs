using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class SelectInvestigatorUseCase : IInitializable
    {
        private string investigatorSelected;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;

        /*******************************************************************/
        public void Initialize() => selectInvestigatorEvent.AddAction(SelectInvestigator);

        /*******************************************************************/
        private void SelectInvestigator(string activeInvestigatorId)
        {
            RemoveGlowInOldInvestigator();
            ActiveGlowInNewInvestigator(activeInvestigatorId);
            investigatorSelected = activeInvestigatorId;
        }

        private void RemoveGlowInOldInvestigator() =>
           investigatorSelectorsManager.GetSelectorById(investigatorSelected)?.Glow(false);

        private void ActiveGlowInNewInvestigator(string activeInvestigatorId) =>
           investigatorSelectorsManager.GetSelectorById(activeInvestigatorId)?.Glow(true);
    }
}
