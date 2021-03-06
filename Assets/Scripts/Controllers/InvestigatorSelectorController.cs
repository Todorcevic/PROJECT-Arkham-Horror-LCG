using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Zenject;
using System.Linq;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IInitializable
    {
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;

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
            selectInvestigator.SelectInvestigator(selectorView.Id);
        }

        private void DoubleClick(IViewInteractable selectorView)
        {
            selectorView.Interactable.ClickEffect();
            removeInvestigator.RemoveInvestigator(selectorView.Id);
            selectInvestigator.SelectInvestigator(investigatorSelectorInteractor.LeadInvestigator);
        }
    }
}
