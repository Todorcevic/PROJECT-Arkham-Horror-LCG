using Arkham.Controllers;
using Arkham.Managers;
using Arkham.Models;
using Arkham.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Presenters
{
    public class CampaignPresenter : ICampaignPresenter
    {
        [Inject] private readonly ICampaignsManager campaignsManager;

        /*******************************************************************/
        public void SetCampaign(CampaignInfo campaignInfo)
        {
            ICampaignState state = campaignsManager.GetCampaignState(campaignInfo.State);
            ICampaignView campaign = campaignsManager.GetCampaign(campaignInfo.Id);
            state.ExecuteState(campaign);
        }
    }
}
