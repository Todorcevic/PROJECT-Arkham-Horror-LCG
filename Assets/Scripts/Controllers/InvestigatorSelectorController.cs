using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IInitializable
    {
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        public void Initialize()
        {
            foreach (IInteractableView interactableView in investigatorSelectorsManager.Selectors)
                Suscribe(interactableView);
        }

        /*******************************************************************/
        private void Suscribe(IInteractableView selectorView)
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
