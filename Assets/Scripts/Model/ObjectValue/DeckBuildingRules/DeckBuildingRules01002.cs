using System.Collections.Generic;

namespace Arkham.Model
{
    public class DeckBuildingRules01002 : DeckBuildingRulesBase
    {
        protected override List<string> DeckBuildingFactionConditions => new List<string>() { "seeker", "mystic", "neutral" };
        protected override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
