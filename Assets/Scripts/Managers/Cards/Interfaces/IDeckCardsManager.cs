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
        DeckCardView DeckCardPrefab { get; }
        Dictionary<string, IDeckCardView> AllDeckCards { get; }
        List<IDeckCardView> DeckCardsList { get; }
        Transform Zone { get; }
        Sprite GetSpriteCard(string id);
    }
}
