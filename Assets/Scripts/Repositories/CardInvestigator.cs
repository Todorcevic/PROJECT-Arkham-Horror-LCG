using Arkham.Investigators;
using Arkham.Models;
using Arkham.Views;
using Zenject;

namespace Arkham.Repositories
{
    public class CardInvestigator
    {
        [Inject] public readonly Repository allData;

        public CardInvestigator(string id, ICardInvestigatorView view, DeckBuildingRules rules)
        {
            Id = id;
            View = view;
            DeckBuildingRules = rules;
        }

        public string Id { get; }
        public CardInfo Info => allData.AllCardsInfo[Id];
        public Investigator Data => allData.AllInvestigators[Id];
        public ICardInvestigatorView View { get; }
        public DeckBuildingRules DeckBuildingRules { get; }
    }
}
