using Arkham.Controllers;
using Arkham.ScriptableObjects;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Managers
{
    public interface ICampaignsManager
    {
        List<CampaignView> Campaigns { get; }
        ICampaignView GetCampaign(string campaignId);
        ICampaignState GetCampaignState(string campaignState);
    }
}
