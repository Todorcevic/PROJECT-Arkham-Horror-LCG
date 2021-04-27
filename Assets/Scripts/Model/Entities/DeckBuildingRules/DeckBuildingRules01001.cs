using System.Collections.Generic;

namespace Arkham.Entities
{
    public class DeckBuildingRules01001 : DeckBuildingRules
    {
        protected override List<string> DeckBuildingFactionConditions => new List<string>() { "guardian", "seeker", "neutral" };
        protected override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
