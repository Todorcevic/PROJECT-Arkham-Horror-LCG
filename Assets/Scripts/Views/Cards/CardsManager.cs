using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Views
{
    public class CardsManager : ICardsManager
    {
        private readonly Dictionary<string, CardView> deckCards = new Dictionary<string, CardView>();
        private readonly Dictionary<string, InvestigatorCardView> investigatorCards = new Dictionary<string, InvestigatorCardView>();

        public List<CardView> AllCards => DeckList.Concat(InvestigatorList).ToList();
        public List<CardView> DeckList => deckCards.Values.ToList();
        public List<InvestigatorCardView> InvestigatorList => investigatorCards.Values.ToList();

        /*******************************************************************/
        public CardView GetDeckCard(string cardId) => deckCards[cardId];

        public CardView GetInvestigatorCard(string cardId) => investigatorCards[cardId];

        public void AddDeckCard(string cardId, CardView cardView) => deckCards.Add(cardId, cardView);

        public void AddInvestigatorCard(string cardId, InvestigatorCardView cardView) => investigatorCards.Add(cardId, cardView);

        public Sprite GetSpriteCard(string id) => id != null ? AllCards.Find(c => c.Id == id).GetCardImage : null;
    }
}
