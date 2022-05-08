using System.Collections.Generic;

namespace Arkham.Model
{
    public class CampaignsRepository
    {
        private List<Campaign> campaigns;

        public bool IsScenarioFinished => string.IsNullOrEmpty(CurrentScenario?.Id);
        public Scenario CurrentScenario { get; private set; }
        public IEnumerable<Campaign> Campaigns => campaigns;

        /*******************************************************************/
        public Campaign Get(string campaignId) => campaigns.Find(campaign => campaign.Id == campaignId);

        public void SetScenario(Scenario scenario) => CurrentScenario = scenario;

        public void Reset()
        {
            CurrentScenario = null;
            campaigns = new List<Campaign>();
        }

        public void Add(Campaign campaign) => campaigns.Add(campaign);

        public void SelectFirstScenarioOf(string campaignId) => CurrentScenario = Get(campaignId)?.FirstScenario;
    }
}
