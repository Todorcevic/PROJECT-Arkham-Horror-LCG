using Arkham.EventData;
using Arkham.Interactors;
using Zenject;

namespace Arkham.View
{
    public class CampaignPresenter : IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;
        [Inject] private readonly ICampaignEvent changeCampaignEvent;
        [Inject] private readonly IStartGameEvent startGameEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            startGameEvent.AddAction(InitializeCampaigns);
            changeCampaignEvent.AddAction(ExecuteStateWithCampaign);
        }

        private void InitializeCampaigns()
        {
            foreach (string campaignId in campaignInteractor.CampaignsList)
            {
                string state = campaignInteractor.GetState(campaignId);
                ExecuteStateWithCampaign(campaignId, state);
            }
        }

        private void ExecuteStateWithCampaign(string campaignId, string state)
        {
            CampaignView campaign = campaignManager.GetCampaign(campaignId);
            campaignManager.GetState(state).ExecuteState(campaign);
        }
    }
}
