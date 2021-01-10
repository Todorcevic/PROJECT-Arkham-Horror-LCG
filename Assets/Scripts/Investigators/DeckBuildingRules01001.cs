using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Model;
using System.Linq;

namespace Arkham.Investigators
{
    public class DeckBuildingRules01001 : DeckBuildingRules
    {
        public override List<string> DeckBuildingFactionConditions => new List<string>() { "guardian", "seeker" };
        public override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2 };
    }
}
