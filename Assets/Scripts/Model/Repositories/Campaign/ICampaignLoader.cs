using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICampaignLoader
    {
        string CurrentScenario { set; get; }
        List<CampaignInfo> CampaignsList { get; set; }
    }
}
