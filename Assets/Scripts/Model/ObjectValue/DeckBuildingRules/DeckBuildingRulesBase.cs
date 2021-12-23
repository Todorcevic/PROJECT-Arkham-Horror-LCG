using System.Collections.Generic;
using Zenject;

namespace Arkham.Model
{
    public abstract class DeckBuildingRulesBase : DeckBuildingRules
    {
        private List<Card> allowedCards;
        [Inject] private readonly CardRepository cardRepository;

        public override int DeckSize => 30;
        public override List<Card> AllowedCards => allowedCards ??= Rules();
        protected abstract List<string> DeckBuildingFactionConditions { get; }
        protected abstract List<int> DeckBuildingXpConditions { get; }

        /*******************************************************************/
        private List<Card> Rules()
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
