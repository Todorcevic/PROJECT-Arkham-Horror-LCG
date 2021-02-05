using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Arkham.Views;

namespace Arkham.Repositories
{
    public class CardRepository
    {
        public List<CardInvestigator> CardInvestigatorList => AllCardInvestigator.Values.ToList();
        public Dictionary<string, CardInvestigator> AllCardInvestigator { get; set; } =
            new Dictionary<string, CardInvestigator>();

        public List<CardDeck> CardDeckList => AllCardDeck.Values.ToList();
        public Dictionary<string, CardDeck> AllCardDeck { get; set; } =
            new Dictionary<string, CardDeck>();

        public List<ICardView> AllCardList => AllCards.Values.ToList();
        public Dictionary<string, ICardView> AllCards { get; set; } = new Dictionary<string, ICardView>();

        public ICardView GetCardView(string id)
        {
            if (AllCardInvestigator.TryGetValue(id, out CardInvestigator card)) return card.View;
            return null;
        }
    }
}
