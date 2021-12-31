using System;
using System.Collections.Generic;

namespace Arkham.Application.GamePlay
{
    public class CardsManager
    {
        private readonly Dictionary<Guid, CardView> cards = new Dictionary<Guid, CardView>();
        private IEnumerable<CardView> AllListCards => cards.Values;

        /*******************************************************************/
        public void AddCard(CardView cardView) => cards.Add(cardView.Guid, cardView);

        public CardView Get(Guid cardGuid) => cards[cardGuid];
    }
}
