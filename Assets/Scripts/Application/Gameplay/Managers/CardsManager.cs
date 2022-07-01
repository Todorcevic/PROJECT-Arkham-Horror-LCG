using Arkham.Model;
using System;
using System.Collections.Generic;

namespace Arkham.Application.GamePlay
{
    public class CardsManager
    {
        private readonly Dictionary<Card, CardView> cards = new Dictionary<Card, CardView>();
        private IEnumerable<CardView> AllListCards => cards.Values;

        /*******************************************************************/
        public void AddCard(CardView cardView, Card Card) => cards.Add(Card, cardView);

        public CardView Get(Card card) => cards[card];
    }
}
