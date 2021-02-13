using Arkham.Controllers;
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
        [Inject] private readonly CampaignsComponent components;
        [Inject] private readonly ICampaignRepository repository;
        [Inject] private readonly ICampaignController controller;

        private List<ICampaignView> Campaigns => components.Campaigns;
        private List<ICampaignState> States => components.States;

        /*******************************************************************/
        public void Init()
        {
            foreach (ICampaignView campaign in Campaigns)
            {
                SetState(campaign);
                campaign.AddClickAction(() => controller.Click(campaign));
                campaign.AddHoverOnAction(() => controller.HoverOn(campaign));
                campaign.AddHoverOffAction(() => controller.HoverOff(campaign));
            }
        }

        private void SetState(ICampaignView campaign) => GetState(campaign.Id).ExecuteState(campaign);

        private ICampaignState GetState(string campaignId) =>
            States.Find(state => state.Id == repository.GetCampaign(campaignId).State);
    }
}
