using Arkham.Models;
using Arkham.Presenters;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Interactors
{
    public class CampaignInteractor : ICampaignInteractor
    {
        [Inject] private readonly ICampaignRepository campaignModel;
        [Inject] private readonly ICampaignPresenter campaignPresenter;

        /*******************************************************************/
        public void InitializeCampaigns()
        {
            foreach (CampaignInfo campaign in campaignModel.CampaignsList)
                campaignPresenter.SetCampaign(campaign);
        }

        public void AddScenarioToPlay(string scenario) => campaignModel.CurrentScenario = scenario;
    }
}
