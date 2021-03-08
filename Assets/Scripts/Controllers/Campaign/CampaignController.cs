using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : IController
    {
        [Inject] private readonly IChangeCampaign changeCampaign;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        public void Click(IViewInteractable campaignView)
        {
            if (!IsCampaignOpen(campaignView.Id)) return;
            campaignView.InteractableEffects.ClickEffect();
            changeCampaign.SelectScenario(campaignInteractor.GetScenario(campaignView.Id));
            selectInvestigator.SelectInvestigator(investigatorSelectorInteractor.LeadInvestigator);
        }

        public void DoubleClick(IViewInteractable campaignView) => campaignView.InteractableEffects.ClickEffect();

        public void HoverOn(IViewInteractable campaignView) => campaignView.InteractableEffects.HoverOnEffect();

        public void HoverOff(IViewInteractable campaignView) => campaignView.InteractableEffects.HoverOffEffect();

        private bool IsCampaignOpen(string campaignId)
        {
            string state = campaignInteractor.GetState(campaignId);
            return campaignsManager.GetState(state).IsOpen;
        }
    }
}
