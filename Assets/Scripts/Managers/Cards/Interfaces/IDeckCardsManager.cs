using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IDeckCardsManager
    {
        Transform Zone { get; }
        DeckCardView CardPrefab { get; }
        Dictionary<string, IDeckCardView> AllCards { get; }
        List<IDeckCardView> CardsList { get; }
        Sprite GetSpriteCard(string id);
    }
}
