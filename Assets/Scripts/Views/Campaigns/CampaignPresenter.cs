using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class CampaignPresenter : IInitializable
    {
        [Inject] private readonly CampaignsManager campaignManager;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly CampaignEventDomain campaignChangedEvent;

        /*******************************************************************/
        void IInitializable.Initialize() => campaignChangedEvent.Subscribe(ExecuteStateWithCampaign);

        public void InitializeCampaigns()
        {
            foreach (Campaign campaign in campaignRepository.Campaigns)
                ExecuteStateWithCampaign(campaign.Id, campaign.State.Id);
        }

        private void ExecuteStateWithCampaign(string campaignId, string state)
        {
            CampaignView campaign = campaignManager.GetCampaign(campaignId);
            campaignManager.GetState(state).ExecuteState(campaign);
            campaign.IsOpen = campaignRepository.Get(campaignId).State.IsOpen;
        }
    }
}
