using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectPresenter : IInitializable
    {
        private string investigatorSelected;
        [Inject] private readonly InvestigatorSelectorEventDomain selectInvestigatorEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;

        /*******************************************************************/
        public void Initialize() => selectInvestigatorEvent.Select(SelectInvestigator);

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
