using System;
using System.Collections.Generic;

namespace Arkham.Model
{
    public class Zone
    {
        private List<Card> cards = new List<Card>();

        public Guid Guid { get; set; }
        public ZoneType Type { get; set; }

        /*******************************************************************/

        public void EnterThisCard(Card card) => cards.Add(card);

        public void ExitThisCard(Card card) => cards.Remove(card);

        public bool ContainThisCard(Card card) => cards.Contains(card);
    }
}
