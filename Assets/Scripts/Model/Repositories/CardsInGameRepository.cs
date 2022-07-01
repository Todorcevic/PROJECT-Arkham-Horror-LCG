using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class CardsInGameRepository
    {
        private List<Card> allCards;

        public IEnumerable<Card> AllListCards => allCards;

        /*******************************************************************/
        public void Add(Card card) => allCards.Add(card);

        public void Reset() => allCards = new List<Card>();

        public List<T> GetAllCardsOfType<T>() where T : Card => AllListCards.OfType<T>().ToList();

        public List<Card> GetAllCardsOfThisPlayer(Player player) =>
            AllListCards.Where(card => card.Owner == player).ToList();

        public List<T> GetCardsOfTypeForThisPlayer<T>(Player player) where T : Card =>
            AllListCards.OfType<T>().Where(card => card.Owner == player).ToList();
    }
}
