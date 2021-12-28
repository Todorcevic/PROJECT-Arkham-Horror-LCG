using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class CardRepository
    {
        private List<CardInfo> cardList;
        private Dictionary<string, CardInfo> cardDict;

        public IEnumerable<CardInfo> AllCards => cardList;

        /*******************************************************************/
        public void CreateWith(List<CardInfo> cards)
        {
            cardList = cards;
            cardDict = cards.ToDictionary(card => card.Id);
        }

        public CardInfo Get(string cardId) => cardDict[cardId];

        public List<CardInfo> FindAll(Predicate<CardInfo> filter) => cardList.FindAll(filter);
    }
}
