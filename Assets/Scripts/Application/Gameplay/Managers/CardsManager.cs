using Arkham.Model;
using System.Collections.Generic;

namespace Arkham.Application.GamePlay
{
    public class CardsManager
    {
        private readonly Dictionary<Card, CardView> cards = new Dictionary<Card, CardView>();

        /*******************************************************************/
        public void AddCard(CardView cardView, Card Card) => cards.Add(Card, cardView);

        public CardView GetCardView(Card card) => cards[card];
    }
}
