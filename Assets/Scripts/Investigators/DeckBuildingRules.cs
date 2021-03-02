using System.Collections.Generic;
using Arkham.Repositories;
using Zenject;
using Arkham.Entities;

namespace Arkham.Investigators
{
    public class DeckBuildingRules
    {
        [Inject] private readonly ICardInfoRepository infoRepository;
        public virtual int DeckSize => 30;
        public virtual List<string> DeckBuildingFactionConditions => new List<string>();
        public virtual List<int> DeckBuildingXpConditions => new List<int>();

        public virtual List<string> DeckBuilding(object[] args)
        {
            List<string> deckBuildingResult = new List<string>();
            int i = 0;
            foreach (string faction in DeckBuildingFactionConditions)
            {
                deckBuildingResult.AddRange(infoRepository.CardInfoList.FindAll(c => c.Faction_code == faction && c.Xp <= DeckBuildingXpConditions[i])
                    .ConvertAll(c => c.Code));
                i++;
            }
            return deckBuildingResult;
        }
    }
}
