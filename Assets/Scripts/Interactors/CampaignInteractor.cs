using Arkham.Models;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
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
        public void ChangeCampaignState(string campaignId, string state, bool isOpen)
        {
            CampaignInfo campaign = GetCampaign(campaignId);
            campaign.State = state;
            campaign.IsOpen = isOpen;
            CampaignStateChanged?.Invoke(campaign);
        }

        public void AddScenarioToPlay(string scenario) => campaignRepository.CurrentScenario = scenario;

        public CampaignInfo GetCampaign(string campaignId) => campaignRepository.CampaignsList.Find(campaign => campaign.Id == campaignId);
    }
}
