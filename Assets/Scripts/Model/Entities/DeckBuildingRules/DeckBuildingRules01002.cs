using System.Collections.Generic;

namespace Arkham.Entities
{
    public class DeckBuildingRules01002 : DeckBuildingRules
    {
        protected override List<string> DeckBuildingFactionConditions => new List<string>() { "seeker", "mystic", "neutral" };
        protected override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
