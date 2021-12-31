using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arkham.Model
{
    public class Zone
    {
        private List<Card> cards = new List<Card>();

        public Guid Guid { get; } = Guid.NewGuid();
        public ZoneType Type { get; }
        public ReadOnlyCollection<Card> Cards => cards.AsReadOnly();

        /*******************************************************************/
        public Zone(ZoneType type)
        {
            Type = type;
        }

        /*******************************************************************/
        public void EnterThisCard(Card card) => cards.Add(card);

        public void ExitThisCard(Card card) => cards.Remove(card);

        public bool ContainThisCard(Card card) => cards.Contains(card);

        public bool ContainThisCard(Guid cardGuid) => cards.Exists(card => card.Guid == cardGuid);
    }
}
