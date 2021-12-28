using System.Collections.Generic;

namespace Arkham.Model
{
    public class UnlockCardsRepository
    {
        private List<CardInfo> cards = new List<CardInfo>();

        /*******************************************************************/
        public bool IsThisCardUnlocked(CardInfo card) => cards.Contains(card);

        public void Reset() => cards = new List<CardInfo>();

        public void Add(CardInfo card) => cards.Add(card);

        public List<string> Serialize() => cards.ConvertAll(card => card.Id);
    }
}
