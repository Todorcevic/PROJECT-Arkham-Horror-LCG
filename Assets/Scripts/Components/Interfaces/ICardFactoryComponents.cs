using Arkham.Controllers;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Components
{
    public interface ICardFactoryComponents
    {
        DeckCardView CardDeckPrefab { get; }
        InvestigatorCardView CardInvestigatorPrefab { get; }
        List<Sprite> CardImagesEN { get; }
        List<Sprite> CardImagesES { get; }
        Transform InvestigatorsZone { get; }
        Transform DeckZone { get; }
    }
}
