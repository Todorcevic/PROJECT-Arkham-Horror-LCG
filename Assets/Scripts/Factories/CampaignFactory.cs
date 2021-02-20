using Arkham.Controllers;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Models;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Factories
{
    public class CampaignFactory : ICampaignFactory
    {
        [Inject] private readonly ICampaignController campaignController;
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignInteractor campaignInteractor;

        public void BuildCampaigns()
        {
            foreach (ICampaignView campaign in campaignsManager.Campaigns)
                campaignController.Init(campaign);

            campaignInteractor.InitializeCampaigns();
        }
    }
}
