using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (IViewInteractable interactableView in campaignsManager.Campaigns)
                Suscribe(interactableView);
        }

        private void Suscribe(IViewInteractable campaignView)
        {
            campaignView.Interactable.Clicked += () => Click(campaignView);
            campaignView.Interactable.DoubleClicked += campaignView.Interactable.DoubleClickEffect;
            campaignView.Interactable.HoverOn += campaignView.Interactable.HoverOnEffect;
            campaignView.Interactable.HoverOff += campaignView.Interactable.HoverOffEffect;
        }

        private void Click(IViewInteractable campaignView)
        {
            if (!IsCampaignOpen(campaignView.Id)) return;
            campaignView.Interactable.ClickEffect();
            campaignInteractor.CurrentScenario = campaignInteractor.GetScenario(campaignView.Id);
            investigatorSelectorInteractor.SelectLeadInvestigator();
        }

        private bool IsCampaignOpen(string campaignId)
        {
            string state = campaignInteractor.GetState(campaignId);
            return campaignsManager.GetState(state).IsOpen;
        }
    }
}
