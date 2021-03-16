using Arkham.Investigators;
using Arkham.Managers;
using Arkham.Entities;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using Arkham.Repositories;

namespace Arkham.Factories
{
    public class InvestigatorCardFactory : CardFactory, IInvestigatorCardFactory
    {
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;

        protected override ICardsManager CardsManager => investigatorCardsManager;
        protected override IEnumerable<string> Cards => infoRepository.CardInfoList
                .FindAll(c => c.Type_code == "investigator" && imageCards.ExistThisSprite(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code).Select(c => c.Code);

    }
}
