using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arkham.Views;
using UnityEngine;

namespace Arkham.Repositories
{
    public class CardRepository : ISpriteCardRepository
    {
        public List<CardBase> CardList => AllCard.Values.ToList();
        public Dictionary<string, CardBase> AllCard { get; set; } = new Dictionary<string, CardBase>();

        public CardView GetCardView(string id) => AllCard[id].View;
        public Sprite GetSpriteCard(string id) => AllCard[id].View.GetCardImage;

        public CardInvestigator GetCardInvestigator(string id)
        {
            if (AllCard[id] is CardInvestigator cardInvestigator) return cardInvestigator;
            throw new Exception(id + " not is CardInvestigator");
        }

        public CardDeck GetCardDeck(string id)
        {
            if (AllCard[id] is CardDeck cardDeck) return cardDeck;
            throw new Exception(id + " not is CardDeck");
        }
    }
}
