using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class CampaignPresenter : IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignManager;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly CampaignEventDomain campaignChangedEvent;
        [Inject] private readonly StartGameEventDomain gameStartedEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            gameStartedEvent.Subscribe((_) => InitializeCampaigns());
            campaignChangedEvent.Subscribe(ExecuteStateWithCampaign);
        }

        private void InitializeCampaigns()
        {
            foreach (Campaign campaign in campaignRepository.Campaigns)
                ExecuteStateWithCampaign(campaign.Id, campaign.State.Id);
        }

        private void ExecuteStateWithCampaign(string campaignId, string state)
        {
            CampaignView campaign = campaignManager.GetCampaign(campaignId);
            campaignManager.GetState(state).ExecuteState(campaign);
            //campaign.IsOpen = campaignRepository.Get(campaignId).State.IsOpen;
        }
    }
}
