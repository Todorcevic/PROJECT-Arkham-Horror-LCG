using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Models;
using System.Linq;

namespace Arkham.Investigators
{
    public class DeckBuildingRules01002 : DeckBuildingRules
    {
        public override List<string> DeckBuildingFactionConditions => new List<string>() { "seeker", "mystic", "neutral" };
        public override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
