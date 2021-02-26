using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Arkham.Models;
using Arkham.Investigators;
using Arkham.Repositories;
using Arkham.Managers;
using Arkham.Controllers;
using Arkham.Views;
using Arkham.Components;
using Arkham.Services;
using Zenject;
using Arkham.Presenters;
using Arkham.Interactors;

namespace Arkham.Factories
{
    public class CardFactory : ICardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly IInstantiatorAdapter instantiator;
        [Inject] private readonly IImagesCard imageCards;
        [Inject] private readonly ICardInfoRepository infoRepository;
        [Inject] private readonly IDeckBuilderInteractor investigatorRepository;
        [Inject] private readonly IInvestigatorCardController investigatorCardController;
        [Inject] private readonly IInvestigatorCardsManager investigatorsCardManager;
        [Inject] private readonly IInvestigatorCardPresenter investigatorCardPresenter;
        [Inject] private readonly IDeckCardsManager deckCardManager;
        [Inject] private readonly IDeckCardController deckCardController;
        [Inject] private readonly IRowCardsManager rowCardManager;
        [Inject] private readonly IRowCardController rowCardController;
        [Inject] private readonly IRowCardPresenter rowCardPresenter;

        private List<Sprite> ImageListEN => imageCards.CardImagesEN;
        private List<Sprite> ImageListES => imageCards.CardImagesES;

        /*******************************************************************/
        public void BuildCards()
        {
            BuildInvestigators();
            BuildDeckCards();
            BuildRowCards();
        }

        private void BuildInvestigators()
        {
            var allInvestigators = infoRepository.CardInfoList
                .FindAll(c => c.Type_code == "investigator" && ImageListEN.Exists(x => x.name == c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);

            foreach (CardInfo investigatorInfo in allInvestigators)
            {
                Create(investigatorInfo.Code, investigatorsCardManager, investigatorCardController);
                SettingDeckBuilding(investigatorInfo.Code);
            }

            investigatorCardPresenter.Init();
        }

        private void SettingDeckBuilding(string investigatorId)
        {
            InvestigatorInfo investigator = investigatorRepository.GetInvestigatorById(investigatorId);
            investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigatorId);
        }

        private void BuildDeckCards()
        {
            var allDeckCards = infoRepository.CardInfoList
                .FindAll(c => (c.Type_code == "asset"
                || c.Type_code == "event"
                || c.Type_code == "skill")
                && (c.Subtype_code != "basicweakness"
                && c.Subtype_code != "weakness")
                && ImageListEN
                .Exists(x => x.name == c.Code)).OrderBy(c => c.Faction_code).ThenBy(c => c.Code);

            foreach (CardInfo card in allDeckCards)
                Create(card.Code, deckCardManager, deckCardController);
        }

        private void BuildRowCards()
        {
            var allRowCards = infoRepository.CardInfoList
                .FindAll(c => (c.Type_code == "asset"
                || c.Type_code == "event"
                || c.Type_code == "skill"
                || c.Subtype_code == "weakness"
                || c.Subtype_code == "basicweakness") && ImageListEN
                .Exists(x => x.name == c.Code)).OrderBy(c => c.Faction_code).ThenBy(c => c.Code);

            foreach (CardInfo rowCard in allRowCards)
                Create(rowCard.Code, rowCardManager, rowCardController);

            rowCardPresenter.Init();
        }

        private void Create(string cardId, ICardsManager manager, ICardController controller)
        {
            CardView cardView = Instantiate(cardId, manager.CardPrefab, manager.Zone);
            manager.AllCards.Add(cardId, cardView);
            controller.Init(cardView);
        }

        private CardView Instantiate(string cardId, CardView prefab, Transform zone)
        {
            CardView cardView = GameObject.Instantiate(prefab, zone);
            cardView.Init(cardId, GetSprite(cardId));
            diContainer.Inject(cardView.Interactable);
            return cardView;
        }

        private Sprite GetSprite(string id) => ImageListEN.Find(c => c.name == id);
    }
}
