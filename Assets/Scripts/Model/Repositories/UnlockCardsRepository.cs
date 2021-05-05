using System.Collections.Generic;

namespace Arkham.Model
{
    public class UnlockCardsRepository
    {
        private List<Card> cards;

        /*******************************************************************/
        public bool IsThisCardUnlocked(Card card) => cards.Contains(card);

        public void Reset() => cards = new List<Card>();

        public void Add(Card card) => cards.Add(card);

        public List<string> Serialize() => cards.ConvertAll(card => card.Id);
    }
}
