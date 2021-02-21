using Arkham.Interactors;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class SelectorController : ISelectorController
    {
        [Inject] private readonly ISelectorInteractor investigatorSelector;

        /*******************************************************************/
        public void Init(ISelectorView selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
            selectorView.Interactable.DoubleClicked += () => DoubleClick(selectorView);
            selectorView.Interactable.HoverOn += () => selectorView.HoverOnEffect();
            selectorView.Interactable.HoverOff += () => selectorView.HoverOffEffect();
        }

        private void Click(ISelectorView selectorView)
        {
            selectorView.Click();
            investigatorSelector.SelectInvestigator(selectorView.InvestigatorInThisSelector);
        }

        private void DoubleClick(ISelectorView selectorView) =>
            investigatorSelector.RemoveInvestigator(selectorView.InvestigatorInThisSelector);
    }
}
