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
        Dictionary<string, IDeckCardView> AllDeckCards { get; }
        List<IDeckCardView> DeckCardsList { get; }
        Transform Zone { get; }
        Sprite GetSpriteCard(string id);
    }
}
