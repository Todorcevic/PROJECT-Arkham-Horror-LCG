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
        public List<ICardComponent> CardComponentsList => AllCardComponents.Values.ToList();
        public Dictionary<string, ICardComponent> AllCardComponents { get; set; } = new Dictionary<string, ICardComponent>();
        public List<IDeckComponent> DeckListCards => CardComponentsList.OfType<IDeckComponent>().ToList();
        public List<IInvestigatorComponent> InvestigatorListCards => CardComponentsList.OfType<IInvestigatorComponent>().ToList();
        public Sprite GetSpriteCard(string id) => AllCardComponents[id].GetCardImage;
    }
}
