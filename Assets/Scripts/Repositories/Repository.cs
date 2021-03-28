using Arkham.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class Repository : ISettings, ICampaignRepository, IInvestigatorRepository, IInvestigatorSelectorRepository, ICardInfoRepository, IUnlockCards
    {
        public bool AreCardsVisible { get; set; }

        /**** Campaigns ****/
        [DataMember] public string CurrentScenario { get; set; }
        [DataMember] public List<CampaignInfo> CampaignsList { get; set; }
        public CampaignInfo GetCampaign(string campaignId) => CampaignsList.Find(c => c.Id == campaignId);

        /**** CardsInfo ****/
        public List<CardInfo> CardInfoList { get; set; }
        public Dictionary<string, CardInfo> CardInfoDict { private get; set; }
        public CardInfo GetCardInfo(string cardId) => CardInfoDict[cardId];

        /**** Investigators ****/
        [DataMember] public List<InvestigatorInfo> InvestigatorsList { get; set; }
        public InvestigatorInfo GetInvestigatorInfo(string investigatorId) => InvestigatorsList.Find(c => c.Id == investigatorId);

        /**** Investigators Selector ****/
        public string CurrentInvestigatorSelected { get; set; }
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }

        /**** Unlock Cards ****/
        [DataMember] public List<string> UnlockCards { get; set; } = new List<string>();

        public bool IsThisCardUnlocked(string cardId) => UnlockCards.Contains(cardId);
    }
}
