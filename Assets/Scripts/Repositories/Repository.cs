using Arkham.Models;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class Repository : ICampaignRepository, IInvestigatorRepository, ISelectorRepository, ICardInfoRepository, IBuildRepository
    {
        private Dictionary<string, CardInfo> allCardsInfo;
        private Dictionary<string, Investigator> allInvestigators;
        private Dictionary<string, Campaign> allCampaigns;

        /**** Info ****/
        public List<CardInfo> CardInfoList { get; set; }
        public Dictionary<string, CardInfo> AllCardsInfo =>
            allCardsInfo ?? (allCardsInfo = CardInfoList.ToDictionary(c => c.Code));

        /**** Selectors ****/
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }

        /**** Investigator ****/
        [DataMember] public List<Investigator> InvestigatorsList { get; set; }
        public Dictionary<string, Investigator> AllInvestigators =>
            allInvestigators ?? (allInvestigators = InvestigatorsList.ToDictionary(i => i.Id));

        /**** Campaigns ****/
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<Campaign> CampaignsList { get; set; }
        public Dictionary<string, Campaign> AllCampaigns =>
            allCampaigns ?? (allCampaigns = CampaignsList.ToDictionary(c => c.Id));
    }
}
