using Arkham.Models;
using System;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICampaignRepository
    {
        event Action<CampaignInfo> CampaignStateChanged;
        string CurrentScenario { get; set; }
        List<CampaignInfo> CampaignsList { get; set; }
        CampaignInfo GetCampaign(string id);
        void ChangeCampaignState(CampaignInfo campaignInfo);

    }
}
