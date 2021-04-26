using Arkham.EventData;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class CampaignPresenter : IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignManager;
        [Inject] private readonly ICampaignInfo campaignInfo;
        [Inject] private readonly ICampaignStateChangedEvent changeCampaignEvent;
        [Inject] private readonly IStartGameEvent startGameEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            startGameEvent.AddAction(InitializeCampaigns);
            changeCampaignEvent.Subscribe(ExecuteStateWithCampaign);
        }

        private void InitializeCampaigns()
        {
            foreach (string campaignId in campaignInfo.CampaignsId)
            {
                string state = campaignInfo.Get(campaignId).State;
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
