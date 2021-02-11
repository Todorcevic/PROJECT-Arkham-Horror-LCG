using Arkham.Models;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class Repository : ICampaignRepository, IInvestigatorRepository, ISelectorRepository, ICardInfoRepository, IBuildRepository
    {
        /**** Info ****/
        public List<CardInfo> CardInfoList { get; set; }
        public CardInfo AllCardsInfo(string id) => CardInfoList.Find(cardInfo => cardInfo.Code == id);

        /**** Selectors ****/
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }

        /**** Investigator ****/
        [DataMember] public List<Investigator> InvestigatorsList { get; set; }
        public Investigator AllInvestigators(string id) => InvestigatorsList.Find(investigator => investigator.Id == id);


        /**** Campaigns ****/
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<Campaign> CampaignsList { get; set; }
        public Campaign GetCampaign(string id) => CampaignsList.Find(campaign => campaign.Id == id);
    }
}
