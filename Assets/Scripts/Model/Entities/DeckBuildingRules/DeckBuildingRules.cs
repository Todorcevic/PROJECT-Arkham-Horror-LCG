﻿using System.Collections.Generic;
using Zenject;

namespace Arkham.Model
{
    public class DeckBuildingRules
    {
        private List<string> allowedCards;
        [Inject] private readonly CardInfoRepository cardInfoRepository;

        public virtual int DeckSize => 30;
        protected virtual List<string> DeckBuildingFactionConditions => new List<string>();
        protected virtual List<int> DeckBuildingXpConditions => new List<int>();

        /*******************************************************************/
        public List<string> AllowedCards() => allowedCards ?? (allowedCards = Rules());

        protected virtual List<string> Rules()
        {
            List<string> deckBuildingResult = new List<string>();
            int i = 0;
            foreach (string faction in DeckBuildingFactionConditions)
            {
                deckBuildingResult.AddRange(cardInfoRepository.FindAll(c => c.Faction_code == faction && c.Xp <= DeckBuildingXpConditions[i])
                    .ConvertAll(c => c.Code));
                i++;
            }
            return allowedCards = deckBuildingResult;
        }
    }
}
