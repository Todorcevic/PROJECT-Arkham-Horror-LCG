using Arkham.Model;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignsManager
    {
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly List<CampaignView> campaigns;
        [Inject] private readonly List<CampaignStateSO> states;

        /*******************************************************************/
        public void InitializeCampaigns()
        {
            foreach (Campaign campaign in campaignRepository.Campaigns)
            {
                CampaignView campaignView = campaigns.Find(campaignview => campaignview.Id == campaign.Id);
                CampaignStateSO state = states.Find(state => state.Id == campaign.State);
                campaignView.SetState(state);
            }
        }
    }
}
