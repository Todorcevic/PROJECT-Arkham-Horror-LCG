using Arkham.Components;
using Arkham.Interactors;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IInitializableController
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        void IInitializableController.Init(IInteractableView selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
            selectorView.Interactable.DoubleClicked += () => DoubleClick(selectorView);
        }

        private void Click(IInteractableView selectorView) =>
            investigatorSelectorInteractor.SelectInvestigator(selectorView.Id);

        private void DoubleClick(IInteractableView selectorView) =>
            investigatorSelectorInteractor.RemoveInvestigator(selectorView.Id);
    }
}
