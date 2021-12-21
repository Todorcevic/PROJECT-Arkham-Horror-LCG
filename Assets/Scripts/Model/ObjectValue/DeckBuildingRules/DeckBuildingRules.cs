using System.Collections.Generic;

namespace Arkham.Model
{
    public interface DeckBuildingRules
    {
        int DeckSize { get; }
        List<Card> AllowedCards { get; }
    }
}
