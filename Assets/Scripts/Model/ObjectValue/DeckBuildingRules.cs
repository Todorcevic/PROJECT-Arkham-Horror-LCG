using System.Collections.Generic;
using Zenject;

namespace Arkham.Model
{
    public class DeckBuildingRules
    {
        private List<Card> allowedCards;
        [Inject] private readonly CardRepository cardRepository;

        public virtual int DeckSize => 30;
        protected virtual List<string> DeckBuildingFactionConditions => new List<string>();
        protected virtual List<int> DeckBuildingXpConditions => new List<int>();
        public List<Card> AllowedCards => allowedCards ?? (allowedCards = Rules());

        /*******************************************************************/

        protected virtual List<Card> Rules()
        {
            List<Card> deckBuildingResult = new List<Card>();
            int i = 0;
            foreach (string faction in DeckBuildingFactionConditions)
            {
                deckBuildingResult.AddRange(cardRepository
                    .FindAll(c => c.Faction_code == faction && c.Xp <= DeckBuildingXpConditions[i]));
                i++;
            }
            return allowedCards = deckBuildingResult;
        }
    }
}
