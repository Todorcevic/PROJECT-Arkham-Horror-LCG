using System.Collections.Generic;

namespace Arkham.Model
{
    public class DeckBuildingRules
    {
        public virtual int DeckSize { get; }
        public virtual List<Card> AllowedCards { get; } = new List<Card>();
    }
}
