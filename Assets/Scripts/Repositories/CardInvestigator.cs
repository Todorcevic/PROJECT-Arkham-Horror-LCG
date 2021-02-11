using Arkham.Investigators;
using Arkham.Models;
using Arkham.Views;
using Zenject;

namespace Arkham.Repositories
{
    public class CardInvestigator : CardBase
    {
        public DeckBuildingRules DeckBuildingRules { get; }
        public CardInvestigator(string id, CardInvestigatorView view, DeckBuildingRules rules) : base(id, view)
        {
            DeckBuildingRules = rules;
        }
    }
}
