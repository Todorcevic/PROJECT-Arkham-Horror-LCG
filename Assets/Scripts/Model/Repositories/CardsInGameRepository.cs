using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class CardsInGameRepository
    {
        private List<Card> allCards;

        public IEnumerable<Card> AllCards => allCards;

        /*******************************************************************/
        public void Add(Card card) => allCards.Add(card);

        public void Reset() => allCards = new List<Card>();

        public List<T> GetAllCardsOfType<T>() where T : Card => AllCards.OfType<T>().ToList();

        public List<Card> GetAllCardsOfThisPlayer(Player player) =>
            AllCards.Where(card => card.Owner == player).ToList();

        public List<T> GetCardsOfTypeForThisPlayer<T>(Player player) where T : Card =>
            AllCards.OfType<T>().Where(card => card.Owner == player).ToList();
    }
}
