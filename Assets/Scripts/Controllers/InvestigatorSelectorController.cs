using Arkham.Components;
using Arkham.Interactors;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IInvestigatorSelectorController
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelector;

        /*******************************************************************/
        public void Init(IInvestigatorSelectorView selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
            selectorView.Interactable.DoubleClicked += () => DoubleClick(selectorView);
        }

        private void Click(IInvestigatorSelectorView selectorView) =>
            investigatorSelector.SelectInvestigator(selectorView.InvestigatorInThisSelector);

        private void DoubleClick(IInvestigatorSelectorView selectorView) =>
            investigatorSelector.RemoveInvestigator(selectorView.InvestigatorInThisSelector);
    }
}
