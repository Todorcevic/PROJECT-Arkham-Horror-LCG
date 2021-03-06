using Arkham.SettingObjects;
using System.Collections.Generic;

namespace Arkham.Managers
{
    public interface ICampaignsManager
    {
        List<ICampaignConfigurable> Campaigns { get; }
        ICampaignConfigurable GetCampaign(string campaignId);
        ICampaignState GetState(string campaignState);
    }
}
