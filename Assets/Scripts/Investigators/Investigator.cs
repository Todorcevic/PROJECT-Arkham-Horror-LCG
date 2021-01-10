using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Investigators
{
    public class Investigator
    {
        public int PhysicTrauma { get; set; }
        public int MentalTrauma { get; set; }
        public int Xp { get; set; }
        public List<string> Deck { get; set; }
        public List<string> MandatoryCards { get; set; }
        [JsonIgnore] public List<string> FullDeck => MandatoryCards.Concat(Deck).ToList();
        public DeckBuildingRules DeckBuilding { get; set; }
    }
}
