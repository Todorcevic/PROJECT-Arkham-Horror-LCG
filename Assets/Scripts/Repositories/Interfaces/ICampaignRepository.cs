using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICampaignRepository
    {
        string CurrentScenario { get; set; }
        CampaignInfo GetCampaign(string id);
        List<CampaignInfo> CampaignsList { get; }
    }
}
