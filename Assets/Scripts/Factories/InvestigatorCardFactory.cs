using Arkham.Components;
using Arkham.Controllers;
using Arkham.Interactors;
using Arkham.Investigators;
using Arkham.Managers;
using Arkham.Models;
using Arkham.Presenters;
using Arkham.Repositories;
using Arkham.Services;
using Arkham.Views;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Factories
{
    public class InvestigatorCardFactory : IInvestigatorCardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly IInstantiatorAdapter instantiator;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ICardInfoRepository infoRepository;
        [Inject] private readonly IDeckBuilderInteractor investigatorRepository;
        [Inject] private readonly IInvestigatorCardController investigatorCardController;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        [Inject] private readonly IInvestigatorCardPresenter investigatorCardPresenter;

        /*******************************************************************/
        public void BuildInvestigators()
        {
            var allInvestigators = infoRepository.CardInfoList
                .FindAll(c => c.Type_code == "investigator" && imageCards.ExistThisSprite(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);

            foreach (CardInfo investigatorInfo in allInvestigators)
            {
                Create(investigatorInfo.Code, investigatorCardsManager, investigatorCardController);
                SettingDeckBuilding(investigatorInfo.Code);
            }

            investigatorCardPresenter.Init();
        }

        private void SettingDeckBuilding(string investigatorId)
        {
            InvestigatorInfo investigator = investigatorRepository.GetInvestigatorById(investigatorId);
            investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigatorId);
        }

        private void Create(string cardId, IInvestigatorCardsManager manager, ICardController controller)
        {
            var args = new object[] { cardId, imageCards.GetSprite(cardId) };
            InvestigatorCardView cardView =
                diContainer.InstantiatePrefabForComponent<InvestigatorCardView>(manager.CardPrefab, manager.Zone, args);
            manager.AllCards.Add(cardId, cardView);
            controller.Init(cardView);
        }
    }
}
