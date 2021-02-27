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
        public event Action<CampaignInfo> CampaignStateChanged;
        [Inject] private readonly ICampaignRepository campaignRepository;
        public string CurrentScenario => campaignRepository.CurrentScenario;
        public List<CampaignInfo> CampaignsList => campaignRepository.CampaignsList;

        /*******************************************************************/
        public void ChangeCampaignState(CampaignInfo campaignInfo)
        {
            campaignRepository.CampaignsList.Find(c => c.Id == campaignInfo.Id).State = campaignInfo.State;
            CampaignStateChanged?.Invoke(campaignInfo);
        }

        public void AddScenarioToPlay(string scenario) => campaignRepository.CurrentScenario = scenario;

        public CampaignInfo GetCampaign(string id) => campaignRepository.CampaignsList.Find(campaign => campaign.Id == id);
    }
}
