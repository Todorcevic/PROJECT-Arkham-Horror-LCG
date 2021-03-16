using Arkham.Entities;
using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class CampaignEventData : IChangeCampaign, ICampaignEvent, IChangeScenario, IScenarioEvent
    {
        [Inject] private readonly ICampaignRepository campaignRepository;
        public event Action<string, string> CampaignStateChanged;
        public event Action<string> CurrentScenarioChanged;

        /*******************************************************************/
        public void ChangeCampaignState(string campaignId, string state)
        {
            campaignRepository.GetCampaign(campaignId).State = state;
            CampaignStateChanged?.Invoke(campaignId, state);
        }

        public void SelectScenario(string scenarioId)
        {
            campaignRepository.CurrentScenario = scenarioId;
            CurrentScenarioChanged?.Invoke(scenarioId);
        }
    }
}
