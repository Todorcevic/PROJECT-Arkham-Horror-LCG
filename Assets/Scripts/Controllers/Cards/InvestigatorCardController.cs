using Arkham.EventData;
using Zenject;

namespace Arkham.Controllers
{
    public class InvestigatorCardController : IController
    {
        [Inject] private readonly IAddInvestigator addInvestigator;
        [Inject] private readonly ISelectInvestigator selectInvestigator;

        /*******************************************************************/
        public void Click(IViewInteractable investigatorCardview)
        {
            investigatorCardview.InteractableEffects.ClickEffect();
            addInvestigator.AddInvestigator(investigatorCardview.Id);
            selectInvestigator.SelectInvestigator(investigatorCardview.Id);
        }

        public void DoubleClick(IViewInteractable investigatorCardview) =>
            investigatorCardview.InteractableEffects.DoubleClickEffect();

        public void HoverOn(IViewInteractable investigatorCardview) =>
            investigatorCardview.InteractableEffects.HoverOnEffect();

        public void HoverOff(IViewInteractable investigatorCardview) =>
            investigatorCardview.InteractableEffects.HoverOffEffect();
    }
}
