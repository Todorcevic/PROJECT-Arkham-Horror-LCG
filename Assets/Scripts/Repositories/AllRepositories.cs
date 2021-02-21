using Arkham.Models;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Arkham.Repositories
{
    [DataContract]
    public class AllRepositories : IInvestigatorRepository, ICardInfoRepository, IRepositories
    {
        /**** CardsInfo ****/
        public List<CardInfo> CardInfoList { get; set; }
        public CardInfo AllCardsInfo(string id) => CardInfoList.Find(cardInfo => cardInfo.Code == id);

        /**** Investigators ****/
        [DataMember] public List<InvestigatorInfo> InvestigatorsList { get; set; }
        public InvestigatorInfo AllInvestigators(string id) => InvestigatorsList.Find(investigator => investigator.Id == id);
    }
}
