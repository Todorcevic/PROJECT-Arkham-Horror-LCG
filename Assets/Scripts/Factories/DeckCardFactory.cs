using Arkham.Managers;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Factories
{
    public class DeckCardFactory : CardFactory, IDeckCardFactory
    {
        [Inject] private readonly IDeckCardsManager deckCardsManager;
        protected override ICardsManager CardsManager => deckCardsManager;
        protected override IEnumerable<string> Cards => infoRepository.CardInfoList
                .FindAll(c => (c.Type_code == "asset"
                || c.Type_code == "event"
                || c.Type_code == "skill")
                && (c.Subtype_code != "basicweakness"
                && c.Subtype_code != "weakness")
                && imageCards.ExistThisSprite(c.Code)).OrderBy(c => c.Faction_code).ThenBy(c => c.Code).Select(c => c.Code);

        /*******************************************************************/
        protected override void ExtraSettings(string cardId)
        {
        }
    }
}
