using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Model
{
    public class CampaignsRepository
    {
        private List<Campaign> campaigns;

        public Scenario CurrentScenario { get; set; }
        public IEnumerable<Campaign> Campaigns => campaigns;

        /*******************************************************************/
        public Campaign Get(string campaignId) => campaigns.Find(campaign => campaign.Id == campaignId);

        public void Reset()
        {
            CurrentScenario = null;
            campaigns = new List<Campaign>();
        }

        public void Add(Campaign campaign) => campaigns.Add(campaign);

        public void SelectFirstScenarioOf(string campaignId) => CurrentScenario = Get(campaignId)?.FirstScenario;
    }
}
