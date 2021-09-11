using Arkham.Config;
using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class CampaignsManager
    {
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly List<CampaignView> campaigns;
        [Inject] private readonly List<CampaignStateSO> states;

        /*******************************************************************/
        public void InitializeCampaigns(StartGame gameType)
        {
            if (gameType != StartGame.New) return;
            foreach (Campaign campaign in campaignRepository.Campaigns)
            {
                CampaignView campaignView = GetCampaign(campaign.Id);
                GetState(campaign.State.Id).ExecuteState(campaignView);
                campaignView.IsOpen = campaign.State.IsOpen;
            }
        }

        private CampaignView GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);

        private CampaignStateSO GetState(string campaignState) => states.Find(s => s.Id == campaignState);
    }
}
