using Arkham.Entities;
using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICampaignRepository
    {
        string CurrentScenario { get; set; }
        List<CampaignInfo> CampaignsList { get; }
        CampaignInfo GetCampaign(string campaignId);
    }
}
