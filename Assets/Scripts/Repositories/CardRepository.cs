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
        public List<ICardView> CardComponentsList => AllCardComponents.Values.ToList();
        public Dictionary<string, ICardView> AllCardComponents { get; set; } = new Dictionary<string, ICardView>();
        public List<IDeckView> DeckListCards => CardComponentsList.OfType<IDeckView>().ToList();
        public List<IInvestigatorView> InvestigatorListCards => CardComponentsList.OfType<IInvestigatorView>().ToList();
        public Sprite GetSpriteCard(string id) => AllCardComponents[id].GetCardImage;
    }
}
