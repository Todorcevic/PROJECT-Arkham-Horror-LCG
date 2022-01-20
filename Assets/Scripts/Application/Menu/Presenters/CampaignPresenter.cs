using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignPresenter
    {
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly CampaignsManager campaignsManager;

        /*******************************************************************/
        public void InitializeCampaigns()
        {
            foreach (Campaign campaign in campaignRepository.Campaigns)
            {
                CampaignView campaignView = campaignsManager.GetCampaign(campaign.Id);
                CampaignStateSO state = campaignsManager.GetState(campaign.State);
                campaignView.SetState(state);
            }
        }
    }
}
