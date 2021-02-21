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
    public class CampaignInteractor : ICampaignInteractor, ICampaignRepository
    {
        public event Action<CampaignInfo> CampaignStateChanged;
        [Inject] private readonly ICampaignPresenter campaignPresenter;
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignInfo> CampaignsList { get; set; }

        /*******************************************************************/
        public void InitializeCampaigns()
        {
            foreach (CampaignInfo campaign in CampaignsList)
                campaignPresenter.SetCampaign(campaign);
        }

        public void ChangeCampaignState(CampaignInfo campaignInfo)
        {
            CampaignsList.Find(c => c.Id == campaignInfo.Id).State = campaignInfo.State;
            CampaignStateChanged?.Invoke(campaignInfo);
        }

        public void AddScenarioToPlay(string scenario) => CurrentScenario = scenario;

        public CampaignInfo GetCampaign(string id) => CampaignsList.Find(campaign => campaign.Id == id);
    }
}
