using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public interface ICardsManager
    {
        Transform Zone { get; }
        CardView CardPrefab { get; }
        Dictionary<string, ICardView> AllCards { get; }
        List<ICardView> CardsList { get; }
        Sprite GetSpriteCard(string id);
    }
}
