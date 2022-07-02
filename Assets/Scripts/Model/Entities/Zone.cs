using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Arkham.Model
{
    public class Zone
    {
        private readonly List<Card> cards = new List<Card>();

        public ReadOnlyCollection<Card> Cards => cards.AsReadOnly();

        /*******************************************************************/
        public void EnterThisCard(Card card) => cards.Add(card);

        public void ExitThisCard(Card card) => cards.Remove(card);

        public bool ContainThisCard(Card card) => cards.Contains(card);
    }
}
