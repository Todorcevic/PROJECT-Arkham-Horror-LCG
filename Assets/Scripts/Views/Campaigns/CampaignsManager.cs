using System.Collections.Generic;
using Zenject;

namespace Arkham.View
{
    public class CampaignsManager : ICampaignsManager
    {
        [Inject] private readonly List<CampaignView> campaigns;
        [Inject] private readonly List<CampaignState> states;

        /*******************************************************************/
        public CampaignView GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);

        public CampaignState GetState(string campaignState) => states.Find(s => s.Id == campaignState);
    }
}
