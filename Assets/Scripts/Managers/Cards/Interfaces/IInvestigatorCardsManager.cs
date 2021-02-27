using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorCardsManager
    {
        Transform Zone { get; }
        InvestigatorCardView CardPrefab { get; }
        Dictionary<string, IInvestigatorCardView> AllCards { get; }
        List<IInvestigatorCardView> CardsList { get; }
        Sprite GetSpriteCard(string id);
    }
}
