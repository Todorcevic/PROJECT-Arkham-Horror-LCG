using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Interactors
{
    public interface ICampaignInteractor
    {
        IEnumerable<string> CampaignsList { get; }
        string GetState(string campaignId);
    }
}
