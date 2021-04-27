using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICampaignInfo
    {
        IEnumerable<string> CampaignsId { get; }
        CampaignInfo Get(string campaignId);
    }
}
