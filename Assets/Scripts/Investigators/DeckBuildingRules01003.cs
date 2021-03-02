using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Entities;
using System.Linq;

namespace Arkham.Investigators
{
    public class DeckBuildingRules01003 : DeckBuildingRules
    {
        public override List<string> DeckBuildingFactionConditions => new List<string>() { "rogue", "guardian", "neutral" };
        public override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
