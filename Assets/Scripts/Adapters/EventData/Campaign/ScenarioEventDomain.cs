using Arkham.Model;
using System;
using Zenject;

namespace Arkham.Adapter
{
    public class ScenarioEventDomain
    {
        [Inject] private readonly CampaignRepository campaignManager;
        private event Action<string> CurrentScenarioChanged;

        /*******************************************************************/
        public void Reset()
        {
            campaignManager.CurrentScenario = null;
            CurrentScenarioChanged?.Invoke(null);
        }

        public void SelectCampaign(string campaignId)
        {
            Scenario scenario = campaignManager.Get(campaignId).FirstScenario;
            campaignManager.CurrentScenario = scenario;
            CurrentScenarioChanged?.Invoke(scenario.Id);
        }

        public void Subscribe(Action<string> action) => CurrentScenarioChanged += action;
    }
}
