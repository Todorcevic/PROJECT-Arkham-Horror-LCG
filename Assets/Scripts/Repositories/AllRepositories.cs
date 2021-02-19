using Arkham.Models;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Arkham.Repositories
{
    [DataContract]
    public class AllRepositories : ICampaignRepository, IInvestigatorRepository, IInvestigatorsSelectedRepository, ICardInfoRepository, IRepositories
    {

        /**** Info ****/
        public List<CardInfo> CardInfoList { get; set; }
        public CardInfo AllCardsInfo(string id) => CardInfoList.Find(cardInfo => cardInfo.Code == id);

        /**** Selectors ****/
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }

        /**** Investigator ****/
        [DataMember] public List<InvestigatorInfo> InvestigatorsList { get; set; }
        public InvestigatorInfo AllInvestigators(string id) => InvestigatorsList.Find(investigator => investigator.Id == id);

        /**** Campaigns ****/
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignInfo> CampaignsList { get; set; }
        public CampaignInfo GetCampaign(string id) => CampaignsList.Find(campaign => campaign.Id == id);
    }
}
