using System.Collections.Generic;

namespace Arkham.View
{
    public interface ICampaignsManager
    {
        CampaignState GetState(string campaignState);
        CampaignView GetCampaign(string campaignId);
    }
}
