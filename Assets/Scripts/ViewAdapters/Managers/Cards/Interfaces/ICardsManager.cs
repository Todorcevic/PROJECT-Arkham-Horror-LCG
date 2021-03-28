using Arkham.Presenters;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface ICardsManager
    {
        Transform Zone { get; }
        CardView CardPrefab { get; }
        Dictionary<string, ICardVisualizable> AllCards { get; }
        List<ICardVisualizable> CardsList { get; }
        Sprite GetSpriteCard(string id);
    }
}
