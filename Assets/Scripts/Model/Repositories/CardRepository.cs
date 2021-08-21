using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class CardRepository
    {
        private List<Card> cardList;
        private Dictionary<string, Card> cardDict;

        public IEnumerable<Card> AllCards => cardList;

        /*******************************************************************/
        public void CreateWith(List<Card> cards)
        {
            cardList = cards;
            cardDict = cards.ToDictionary(c => c.Id);
        }

        public Card Get(string cardId) => cardDict[cardId];

        public List<Card> FindAll(Predicate<Card> filter) => cardList.FindAll(filter);
    }
}
