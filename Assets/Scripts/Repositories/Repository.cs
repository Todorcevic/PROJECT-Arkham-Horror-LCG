using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Repositories
{
    [DataContract]
    public class Repository : IRepository
    {
        /**** Campaigns ****/
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignInfo> CampaignsList { get; set; }

        /**** CardsInfo ****/
        public List<CardInfo> CardInfoList { get; set; }

        /**** Investigators ****/
        [DataMember] public List<InvestigatorInfo> InvestigatorsList { get; set; }

        /**** Investigators Selector ****/
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }
    }
}
