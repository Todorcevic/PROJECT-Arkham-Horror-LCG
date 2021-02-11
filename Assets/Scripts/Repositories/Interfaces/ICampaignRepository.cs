using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICampaignRepository
    {
        string CurrentScenario { get; set; }
        Dictionary<string, Campaign> AllCampaigns { get; }
        List<Campaign> CampaignsList { get; }
    }
}
