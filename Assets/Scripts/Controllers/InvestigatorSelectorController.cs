using Arkham.Interactors;
using Arkham.Managers;
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
            foreach (IViewInteractable interactableView in investigatorSelectorsManager.Selectors)
                Suscribe(interactableView);
        }

        /*******************************************************************/
        private void Suscribe(IViewInteractable selectorView)
        {
            selectorView.Interactable.Clicked += () => Click(selectorView);
            selectorView.Interactable.DoubleClicked += () => DoubleClick(selectorView);
            selectorView.Interactable.HoverOn += selectorView.Interactable.HoverOnEffect;
            selectorView.Interactable.HoverOff += selectorView.Interactable.HoverOffEffect;
        }

        private void Click(IViewInteractable selectorView)
        {
            selectorView.Interactable.ClickEffect();
            investigatorSelectorInteractor.SelectInvestigator(selectorView.Id);
        }

        private void DoubleClick(IViewInteractable selectorView)
        {
            selectorView.Interactable.ClickEffect();
            investigatorSelectorInteractor.RemoveInvestigator(selectorView.Id);
        }
    }
}
