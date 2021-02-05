using Arkham.Models;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class Repository
    {
        private Dictionary<string, CardInfo> allCardsInfo;
        private Dictionary<string, Investigator> allInvestigators;
        private Dictionary<string, Campaign> allCampaigns;
        private Dictionary<int, string> allInvestigatorSelectors;

        [DataMember] public string CurrentScenario { get; set; }
        public List<CardInfo> CardInfoList { get; set; }
        [DataMember] public List<Investigator> InvestigatorsList { get; set; }
        [DataMember] public List<Campaign> CampaignList { get; set; }
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }
        public Dictionary<string, CardInfo> AllCardsInfo => allCardsInfo ?? (allCardsInfo = CardInfoList.ToDictionary(c => c.Code));
        public Dictionary<string, Investigator> AllInvestigators => allInvestigators ?? (allInvestigators = InvestigatorsList.ToDictionary(i => i.Id));
        public Dictionary<string, Campaign> AllCampaigns => allCampaigns ?? (allCampaigns = CampaignList.ToDictionary(c => c.Id));
        public string InvestigatorSelected { get; set; }
    }
}
