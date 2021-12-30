using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class CardsInGameRepository
    {
        private Dictionary<Guid, Card> allCards;

        public Dictionary<Guid, Card> AllCards => allCards;

        /*******************************************************************/
        public void Add(Card card) => allCards.Add(card.Guid, card);

        public void Reset() => allCards = new Dictionary<Guid, Card>();

        public Card GetCard(Guid guid) => allCards[guid];
    }
}
