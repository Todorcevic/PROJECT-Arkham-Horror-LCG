using Arkham.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Repositories
{
    public class CardInfoRepository : ICardInfoLoader, ICardInfo
    {
        private List<CardInfo> cardInfoList;
        private Dictionary<string, CardInfo> cardInfoDict;

        public List<CardInfo> CardInfoList
        {
            set
            {
                cardInfoList = value;
                cardInfoDict = value.ToDictionary(c => c.Code);
            }
        }

        /*******************************************************************/
        public CardInfo Get(string cardId) => cardInfoDict[cardId];

        public List<CardInfo> FindAll(Predicate<CardInfo> filter) => cardInfoList.FindAll(filter);

        public bool ThisCardContainThisText(string cardId, string textToSearch) =>
            Get(cardId).Real_name.ToLower().Contains(textToSearch?.ToLower() ?? "");
    }
}
