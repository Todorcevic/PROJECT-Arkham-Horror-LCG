using Arkham.Repositories;
using Arkham.UI;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Managers
{
    public class CampaignsManager : ICampaignsManager
    {
        [Inject] private readonly ICampaignRepository repository;
        [Inject] private readonly CampaignsComponent components;

        private List<CampaignView> Campaigns => components.Campaigns;
        private List<CampaignState> States => components.States;

        /*******************************************************************/
        public void Init()
        {
            foreach (CampaignView campaign in Campaigns)
                SetState(campaign);
        }

        private void SetState(CampaignView campaign) => GetState(campaign.Id).ExecuteState(campaign);

        private CampaignState GetState(string campaignId) =>
            States.Find(state => state.Id == repository.GetCampaign(campaignId).State);
    }
}
