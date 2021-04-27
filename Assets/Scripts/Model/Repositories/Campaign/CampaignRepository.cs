using Arkham.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class CampaignRepository : ICampaignLoader, ICampaignRepository, ICampaignInfo, IScenarioChangedEvent, ICampaignStateChangedEvent
    {
        private event Action<string, string> CampaignStateChanged;
        private event Action<string> CurrentScenarioChanged;

        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignInfo> CampaignsList { get; set; }
        public IEnumerable<string> CampaignsId => CampaignsList.Select(c => c.Id);

        /*******************************************************************/
        public CampaignInfo Get(string campaignId) => CampaignsList.Find(c => c.Id == campaignId);

        public void ChangeCampaignState(string campaignId, string state)
        {
            Get(campaignId).State = state;
            CampaignStateChanged?.Invoke(campaignId, state);
        }

        public void SelectFirstScenarioOf(string campaignId)
        {
            string firstScenario = Get(campaignId).FirstScenario;
            SelectScenario(firstScenario);
        }

        public void SelectScenario(string scenarioId)
        {
            CurrentScenario = scenarioId;
            CurrentScenarioChanged?.Invoke(scenarioId);
        }

        void ICampaignStateChangedEvent.Subscribe(Action<string, string> action) => CampaignStateChanged += action;

        void IScenarioChangedEvent.Subscribe(Action<string> action) => CurrentScenarioChanged += action;
    }
}
