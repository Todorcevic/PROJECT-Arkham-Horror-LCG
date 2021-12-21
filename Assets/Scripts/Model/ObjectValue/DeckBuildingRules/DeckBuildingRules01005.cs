using System.Collections.Generic;

namespace Arkham.Model
{
    public class DeckBuildingRules01005 : DeckBuildingRulesBase
    {
        protected override List<string> DeckBuildingFactionConditions => new List<string>() { "survivor", "rogue", "neutral" };
        protected override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
