using System.Collections.Generic;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignsManager
    {
        [Inject] private readonly List<CampaignView> campaigns;
        [Inject] private readonly List<CampaignStateSO> states;

        /*******************************************************************/
        public CampaignView GetCampaign(string campaignId) => campaigns.Find(campaignview => campaignview.Id == campaignId);
        public CampaignStateSO GetState(string stateId) => states.Find(state => state.Id == stateId);
    }
}
