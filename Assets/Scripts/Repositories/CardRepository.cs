using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arkham.Views;
using UnityEngine;

namespace Arkham.Repositories
{
    public class CardRepository : ICardComponentRepository, ISpriteCardRepository
    {
        public List<CardController> CardComponentsList => AllCardViews.Values.ToList();
        public Dictionary<string, CardController> AllCardViews { get; set; } = new Dictionary<string, CardController>();
        public List<CardDeckController> DeckListCards => CardComponentsList.OfType<CardDeckController>().ToList();
        public List<CardInvestigatorController> InvestigatorListCards => CardComponentsList.OfType<CardInvestigatorController>().ToList();
        public CardInvestigatorController GetInvestigator(string id)
        {
            if (AllCardViews[id] is CardInvestigatorController investigator) return investigator;
            else throw new Exception(id + " not is CardInvestigator");
        }
        public CardDeckController GetDeck(string id)
        {
            if (AllCardViews[id] is CardDeckController cardDeck) return cardDeck;
            else throw new Exception(id + " not is CardDek");
        }
        public Sprite GetSpriteCard(string id) => AllCardViews[id].GetCardImage;
    }
}
