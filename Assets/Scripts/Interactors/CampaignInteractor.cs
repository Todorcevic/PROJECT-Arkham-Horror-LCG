using Arkham.Models;
using Arkham.Presenters;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Iterators
{
    public class CampaignInteractor : ICampaignInteractor
    {
        [Inject] ICampaignRepository campaignModel;
        [Inject] ICampaignPresenter campaignPresenter;

        /*******************************************************************/
        public void InitializeCampaigns()
        {
            foreach (CampaignInfo campaign in campaignModel.CampaignsList)
                campaignPresenter.SetCampaign(campaign);
        }

        public void AddScenarioToPlay(string scenario) => campaignModel.CurrentScenario = scenario;
    }
}
