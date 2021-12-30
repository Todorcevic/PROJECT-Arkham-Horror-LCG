using System;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Model
{
    public class CardsInGameRepository
    {
        private Dictionary<Guid, Card> allCards;

        public Dictionary<Guid, Card> AllCards => allCards;
        public IEnumerable<Card> AllListCards => allCards.Values;

        /*******************************************************************/
        public void Add(Card card) => allCards.Add(card.Guid, card);

        public void Reset() => allCards = new Dictionary<Guid, Card>();

        public Card GetCard(Guid guid) => allCards[guid];

        public List<T> GetAllCardsOfType<T>() where T : Card => AllListCards.OfType<T>().ToList();

        public List<Card> GetAllCardsOfThisPlayer(Player player) =>
            AllListCards.Where(card => card.Owner == player).ToList();

        public List<T> GetCardsOfTypeForThisPlayer<T>(Player player) where T : Card =>
            AllListCards.OfType<T>().Where(card => card.Owner == player).ToList();
    }
}
