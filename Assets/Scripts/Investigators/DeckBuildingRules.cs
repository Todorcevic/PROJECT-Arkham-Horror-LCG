using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Arkham.Model;
using System.Linq;
using Zenject;

namespace Arkham.Investigators
{
    public class DeckBuildingRules
    {
        [Inject] public GameData gameData;

        public virtual int DeckSize => 30;
        public virtual List<string> DeckBuildingFactionConditions => new List<string>();
        public virtual List<int> DeckBuildingXpConditions => new List<int>();

        public virtual List<string> DeckBuilding()
        {
            List<string> deckBuildingResult = new List<string>();
            int i = 0;
            foreach (string faction in DeckBuildingFactionConditions)
            {
                deckBuildingResult.AddRange(gameData.AllDataCards
                    .Where(c => c.Faction_code == faction && c.Xp <= DeckBuildingXpConditions[i])
                    .Select(c => c.Code).ToList());
                i++;
            }
            return deckBuildingResult;
        }
    }
}
