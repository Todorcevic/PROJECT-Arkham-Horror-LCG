using Zenject;
using System.Collections.Generic;
using Arkham.Model;

namespace Arkham.Application
{
    public class CampaignPresenter
    {
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly CampaignsManager campaignManager;

        /*******************************************************************/
        public void InitializeCampaigns()
        {
            foreach (Campaign campaign in campaignRepository.Campaigns)
            {
                CampaignView campaignView = campaignManager.GetCampaign(campaign.Id);
                campaignManager.GetState(campaign.State.Id).ExecuteState(campaignView);
                campaignView.IsOpen = campaign.State.IsOpen;
            }
        }
    }
}
