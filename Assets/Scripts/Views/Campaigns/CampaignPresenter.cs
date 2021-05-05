using Zenject;
using Arkham.UseCases;
using System.Collections.Generic;

namespace Arkham.Views
{
    public class CampaignPresenter
    {
        [Inject] private readonly CampaignsManager campaignManager;

        /*******************************************************************/
        public void InitializeCampaigns(List<CampaignDTO> campaigns)
        {
            foreach (CampaignDTO campaign in campaigns)
            {
                CampaignView campaignView = campaignManager.GetCampaign(campaign.Id);
                campaignManager.GetState(campaign.State).ExecuteState(campaignView);
                campaignView.IsOpen = campaign.IsOpen;
            }
        }
    }
}
