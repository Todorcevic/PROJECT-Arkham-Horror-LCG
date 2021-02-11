using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICampaignRepository
    {
        string CurrentScenario { get; set; }
        Campaign GetCampaign(string id);
        List<Campaign> CampaignsList { get; }
    }
}
