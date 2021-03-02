using Arkham.Components;
using Arkham.Controllers;
using Arkham.Interactors;
using Arkham.Investigators;
using Arkham.Managers;
using Arkham.Entities;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Factories
{
    public class InvestigatorCardFactory : CardFactory
    {
        [Inject] private readonly IDeckBuilderInteractor investigatorRepository;
        [Inject] private readonly IInvestigatorCardController investigatorCardController;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        protected override ICardsManager CardsManager => investigatorCardsManager;
        protected override ICardController CardController => investigatorCardController;
        protected override IEnumerable<string> Cards => infoRepository.CardInfoList
                .FindAll(c => c.Type_code == "investigator" && imageCards.ExistThisSprite(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code).Select(c => c.Code);

        /*******************************************************************/
        protected override void ExtraSettings(string cardId)
        {
            InvestigatorInfo investigator = investigatorRepository.GetInvestigatorById(cardId);
            investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(cardId);
        }
    }
}
