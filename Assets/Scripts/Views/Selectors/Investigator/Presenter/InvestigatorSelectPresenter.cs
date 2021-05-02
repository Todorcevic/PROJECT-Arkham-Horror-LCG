using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class InvestigatorSelectPresenter : IInitializable
    {
        private string investigatorSelected;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;

        /*******************************************************************/
        public void Initialize() => investigatorSelectEvent.Subscribe(SelectInvestigator);

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
