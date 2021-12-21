using System.Collections.Generic;

namespace Arkham.Model
{
    public class DeckBuildingRules01001 : DeckBuildingRulesBase
    {
        protected override List<string> DeckBuildingFactionConditions => new List<string>() { "guardian", "seeker", "neutral" };
        protected override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
