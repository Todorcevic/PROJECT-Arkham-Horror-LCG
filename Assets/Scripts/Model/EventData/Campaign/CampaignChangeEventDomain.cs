using System;
using Zenject;

namespace Arkham.Model
{
    public class CampaignChangeEventDomain
    {
        [Inject] private readonly CampaignRepository campaignRepository;
        private event Action<string, string> CampaignStateChanged;
        private event Action<string> CurrentScenarioChanged;

        /*******************************************************************/
        public void Change(string campaignId, string state)
        {
            campaignRepository.Get(campaignId).State = state;
            CampaignStateChanged?.Invoke(campaignId, state);
        }

        public void Select(string scenarioId)
        {
            campaignRepository.CurrentScenario = scenarioId;
            CurrentScenarioChanged?.Invoke(scenarioId);
        }

        public void Subscribe(Action<string, string> action) => CampaignStateChanged += action;

        public void Subscribe(Action<string> action) => CurrentScenarioChanged += action;
    }
}
