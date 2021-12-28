using System.Collections.Generic;

namespace Arkham.Model
{
    public class DeckBuildingRules
    {
        public virtual int DeckSize { get; }
        public virtual List<CardInfo> AllowedCards { get; } = new List<CardInfo>();
    }
}
