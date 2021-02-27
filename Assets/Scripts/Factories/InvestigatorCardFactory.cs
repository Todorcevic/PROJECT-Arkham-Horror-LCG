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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Factories
{
    public class InvestigatorCardFactory: IInvestigatorCardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly IInstantiatorAdapter instantiator;
        [Inject] private readonly IImagesCard imageCards;
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
            InvestigatorCardView cardView = Instantiate(cardId, manager.CardPrefab, manager.Zone);
            manager.AllCards.Add(cardId, cardView);
            controller.Init(cardView);
        }

        private InvestigatorCardView Instantiate(string cardId, InvestigatorCardView prefab, Transform zone)
        {
            InvestigatorCardView cardView = GameObject.Instantiate(prefab, zone);
            cardView.Init(cardId, imageCards.GetSprite(cardId));
            diContainer.Inject(cardView.Interactable);
            return cardView;
        }
    }
}
