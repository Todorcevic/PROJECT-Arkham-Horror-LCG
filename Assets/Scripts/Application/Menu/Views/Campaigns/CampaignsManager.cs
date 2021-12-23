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
        public void InitializeCampaigns()
        {
            foreach (Campaign campaign in campaignRepository.Campaigns)
            {
                CampaignView campaignView = campaigns.Find(campaignview => campaignview.Id == campaign.Id);
                states.Find(state => state.Id == campaign.State.Id).ExecuteState(campaignView);
                campaignView.IsOpen = campaign.State.IsOpen;
            }
        }
    }
}
