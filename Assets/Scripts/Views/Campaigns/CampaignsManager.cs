﻿using System.Collections.Generic;
using Zenject;

namespace Arkham.Views
{
    public class CampaignsManager : ICampaignsManager
    {
        [Inject] private readonly List<CampaignView> campaigns;
        [Inject] private readonly List<CampaignStateSO> states;

        /*******************************************************************/
        public CampaignView GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);

        public CampaignStateSO GetState(string campaignState) => states.Find(s => s.Id == campaignState);
    }
}
