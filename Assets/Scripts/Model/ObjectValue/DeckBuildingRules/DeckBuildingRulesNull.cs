using System.Collections.Generic;

namespace Arkham.Model
{
    public class DeckBuildingRulesNull : DeckBuildingRulesBase
    {
        protected override List<string> DeckBuildingFactionConditions => new List<string>();

        protected override List<int> DeckBuildingXpConditions => new List<int>();
    }
}
