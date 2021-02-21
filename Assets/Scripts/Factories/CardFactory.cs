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

namespace Arkham.Factories
{
    public class CardFactory : ICardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly IInstantiatorAdapter instantiator;
        [Inject] private readonly IImagesCard imageCards;
        [Inject] private readonly ICardInfoRepository infoRepository;
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly IInvestigatorCardController investigatorCardController;
        [Inject] private readonly IInvestigatorCardsManager investigatorsManager;
        [Inject] private readonly IInvestigatorCardPresenter investigatorPresenter;
        [Inject] private readonly IDeckCardsManager deckManager;

        //[Inject] private readonly IDeckCardController deckCardController;

        private List<Sprite> ImageListEN => imageCards.CardImagesEN;
        private List<Sprite> ImageListES => imageCards.CardImagesES;

        /*******************************************************************/
        public void BuildCards()
        {
            BuildInvestigators();
            BuildDeckCards();
        }

        private void BuildInvestigators()
        {
            var allInvestigators = infoRepository.CardInfoList
                .FindAll(c => c.Type_code == "investigator" && ImageListEN.Exists(x => x.name == c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo investigatorInfo in allInvestigators)
            {
                CardView cardInvestigatorView = GameObject.Instantiate(investigatorsManager.CardPrefab, investigatorsManager.Zone);
                SettingDeckBuilding(investigatorInfo.Code);
                cardInvestigatorView.Initialize(investigatorInfo.Code, GetSprite(investigatorInfo.Code));
                diContainer.Inject(cardInvestigatorView.Interactable);
                investigatorsManager.AllCards.Add(investigatorInfo.Code, cardInvestigatorView);
                investigatorCardController.Init(cardInvestigatorView);
            }

            investigatorPresenter.Init();
        }

        private void SettingDeckBuilding(string investigatorId)
        {
            InvestigatorInfo investigator = investigatorRepository.AllInvestigators(investigatorId);
            investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigatorId);
        }

        private void BuildDeckCards()
        {
            var allDeckCards = infoRepository.CardInfoList.FindAll(c => (c.Type_code == "asset" || c.Type_code == "event" || c.Type_code == "skill") && ImageListEN.Exists(x => x.name == c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo card in allDeckCards)
            {
                CardView cardDeckView = GameObject.Instantiate(deckManager.CardPrefab, deckManager.Zone);
                cardDeckView.Initialize(card.Code, GetSprite(card.Code));
                diContainer.Inject(cardDeckView.Interactable);
                deckManager.AllCards.Add(card.Code, cardDeckView);
            }
        }

        private Sprite GetSprite(string id) => ImageListEN.Find(c => c.name == id);
    }
}
