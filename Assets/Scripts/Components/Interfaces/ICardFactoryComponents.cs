using Arkham.Controllers;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Components
{
    public interface ICardFactoryComponents
    {
        CardDeckController CardDeckPrefab { get; }
        CardInvestigatorController CardInvestigatorPrefab { get; }
        CardRowController CardRow { get; }
        List<Sprite> CardImagesEN { get; }
        List<Sprite> CardImagesES { get; }
        Transform InvestigatorsZone { get; }
        Transform DeckZone { get; }
    }
}
