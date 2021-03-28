using Arkham.SettingObjects;
using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Managers
{
    public interface ICampaignsManager
    {
        List<CampaignView> Campaigns { get; }
        CampaignView GetCampaign(string campaignId);
        CampaignState GetState(string campaignState);
    }
}
