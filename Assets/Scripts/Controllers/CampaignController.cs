using Arkham.Interactors;
using Arkham.Views;
using Zenject;

namespace Arkham.Controllers
{
    public class CampaignController : IInitializableController
    {
        [Inject] private readonly ICampaignInteractor campaignInteractor;

        /*******************************************************************/
        void IInitializableController.Init(IInteractableView campaignView)
        {
            campaignView.Interactable.Clicked -= campaignView.Interactable.ClickEffect;
            campaignView.Interactable.DoubleClicked -= campaignView.Interactable.DoubleClickEffect;
            campaignView.Interactable.Clicked += () => Click(campaignView);
            campaignView.Interactable.DoubleClicked += () => Click(campaignView);
        }

        private void Click(IInteractableView campaignView)
        {
            var campaign = campaignInteractor.GetCampaign(campaignView.Id);
            if (!campaign.IsOpen) return;
            campaignView.Interactable.ClickEffect();
            campaignInteractor.AddScenarioToPlay(campaign.FirstScenarioId);
        }
    }
}
