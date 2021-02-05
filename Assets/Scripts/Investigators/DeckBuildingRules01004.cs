using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Models;
using System.Linq;

namespace Arkham.Investigators
{
    public class DeckBuildingRules01004 : DeckBuildingRules
    {
        public override List<string> DeckBuildingFactionConditions => new List<string>() { "mystic", "survivor", "neutral" };
        public override List<int> DeckBuildingXpConditions => new List<int>() { 5, 2, 5 };
    }
}
