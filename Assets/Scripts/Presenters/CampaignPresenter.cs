using Arkham.Controllers;
using Arkham.Managers;
using Arkham.Models;
using Arkham.ScriptableObjects;
using Arkham.Views;
using Arkham.Repositories;
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
        [Inject] private readonly ICampaignRepository campaignRepository;
        public List<ICampaignView> Campaigns => campaignsManager.Campaigns;

        /*******************************************************************/
        public void Init()
        {
            campaignRepository.CampaignStateChanged += SetCampaign;
            InitializeCampaigns();
        }

        public void SetCampaign(CampaignInfo campaignInfo)
        {
            ICampaignState state = campaignsManager.GetCampaignState(campaignInfo.State);
            ICampaignView campaign = campaignsManager.GetCampaign(campaignInfo.Id);
            state.ExecuteState(campaign);
        }

        private void InitializeCampaigns()
        {
            foreach (CampaignInfo campaign in campaignRepository.CampaignsList)
                SetCampaign(campaign);
        }
    }
}
