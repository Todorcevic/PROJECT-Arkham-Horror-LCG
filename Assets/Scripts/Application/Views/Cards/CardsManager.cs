using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Application
{
    public class CardsManager
    {
        private readonly Dictionary<string, CardView> cards = new Dictionary<string, CardView>();

        public List<CardView> AllCards => cards.Values.ToList();
        public List<DeckCardView> DeckList => cards.Values.OfType<DeckCardView>().ToList();
        public List<InvestigatorCardView> InvestigatorList => cards.Values.OfType<InvestigatorCardView>().ToList();

        /*******************************************************************/
        public InvestigatorCardView GetInvestigatorCard(string cardId) => (InvestigatorCardView)cards[cardId];

        public DeckCardView GetDeckCard(string cardId) => (DeckCardView)cards[cardId];

        public void AddCard(string cardId, CardView cardView) => cards.Add(cardId, cardView);

        public Sprite GetSpriteCard(string id) => id != null ? AllCards.Find(c => c.Id == id).FrontImage : null;
    }
}
