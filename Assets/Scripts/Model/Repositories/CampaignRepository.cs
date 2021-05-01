using System.Collections.Generic;

namespace Arkham.Model
{
    public class CampaignRepository
    {
        private List<Campaign> campaigns;
        private List<CampaignState> states;

        public Scenario CurrentScenario { get; set; }
        public IEnumerable<Campaign> Campaigns => campaigns;

        /*******************************************************************/
        public Campaign Get(string campaignId) => campaigns.Find(campaign => campaign.Id == campaignId);

        public CampaignState GetState(string stateId) => states.Find(state => state.Id == stateId);

        public void Reset()
        {
            CurrentScenario = null;
            campaigns = new List<Campaign>();
            states = new List<CampaignState>();
        }

        public void Add(Campaign campaign) => campaigns.Add(campaign);

        public void CreateStatesWith(List<CampaignState> states) => this.states = states;
    }
}
