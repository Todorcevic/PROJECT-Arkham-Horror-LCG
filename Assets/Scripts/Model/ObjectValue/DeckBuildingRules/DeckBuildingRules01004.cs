using System.Collections.Generic;

namespace Arkham.Model
{
    public class DeckBuildingRules01004 : DeckBuildingRulesBase
    {
        protected override List<string> DeckBuildingFactionConditions => new List<string>() { "mystic", "survivor", "neutral" };
        protected override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
