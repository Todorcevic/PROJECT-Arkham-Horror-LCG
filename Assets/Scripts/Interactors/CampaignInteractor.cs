using Arkham.Entities;
using Arkham.Repositories;
using System;
using System.Collections;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class CampaignInteractor : ICampaignInteractor
    {
        public event Action<string> CampaignStateChanged;
        [Inject] private readonly ICampaignRepository campaignRepository;
        public string CurrentScenario
        {
            get => campaignRepository.CurrentScenario;
            set => campaignRepository.CurrentScenario = value;
        }
        public IEnumerable CampaignsList => campaignRepository.CampaignsList.Select(c => c.Id);

        /*******************************************************************/
        public void ChangeCampaignState(string campaignId, string state, bool isOpen)
        {
            CampaignInfo campaign = GetCampaign(campaignId);
            campaign.State = state;
            CampaignStateChanged?.Invoke(campaign.Id);
        }

        public string GetState(string campaignId) => GetCampaign(campaignId).State;

        public string GetScenario(string campaignId) => GetCampaign(campaignId).FirstScenarioId;

        private CampaignInfo GetCampaign(string campaignId) =>
            campaignRepository.CampaignsList.Find(campaign => campaign.Id == campaignId);
    }
}
