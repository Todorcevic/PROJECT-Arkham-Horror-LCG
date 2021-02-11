using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arkham.Views;
using UnityEngine;

namespace Arkham.Repositories
{
    public class CardRepository : ICardViewsRepository, ISpriteCardRepository
    {
        public List<CardView> CardViewsList => AllCardViews.Values.ToList();
        public Dictionary<string, CardView> AllCardViews { get; set; } = new Dictionary<string, CardView>();
        public Sprite GetSpriteCard(string id) => AllCardViews[id].GetCardImage;
    }
}
