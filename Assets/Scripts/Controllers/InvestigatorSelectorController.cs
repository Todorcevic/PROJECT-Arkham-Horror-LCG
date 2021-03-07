using Arkham.Interactors;
using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IController
    {
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IRemoveInvestigator removeInvestigator;

        /*******************************************************************/
        public void Click(IViewInteractable selectorView)
        {
            selectorView.InteractableEffects.ClickEffect();
            selectInvestigator.SelectInvestigator(selectorView.Id);
        }

        public void DoubleClick(IViewInteractable selectorView)
        {
            selectorView.InteractableEffects.DoubleClickEffect();
            removeInvestigator.RemoveInvestigator(selectorView.Id);
            selectInvestigator.SelectInvestigator(investigatorSelectorInteractor.LeadInvestigator);
        }

        public void HoverOn(IViewInteractable selectorView) => selectorView.InteractableEffects.HoverOnEffect();

        public void HoverOff(IViewInteractable selectorView) => selectorView.InteractableEffects.HoverOffEffect();
    }
}
