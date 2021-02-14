using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Arkham.Models;
using Arkham.UI;
using Arkham.Views;
using Arkham.Adapters;
using Arkham.Investigators;
using Arkham.Repositories;
using Zenject;
using Arkham.Managers;

namespace Arkham.Factories
{
    public class CardFactory : ICardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly CardFactoryComponent cardFactoryComponent;
        [Inject] private readonly ICardInfoRepository infoRepository;
        [Inject] private readonly IInvestigatorRepository investigatorRepository;
        [Inject] private readonly ICardComponentRepository cardViewsRepository;
        [Inject] private readonly IInstanceAdapter instantiator;
        private List<Sprite> ImageListEN => cardFactoryComponent.CardImagesEN;
        private List<Sprite> ImageListES => cardFactoryComponent.CardImagesES;

        /*******************************************************************/
        public void BuildCards()
        {
            BuildInvestigators();
            BuildDeckCards();
        }

        private void BuildInvestigators()
        {
            var allInvestigators = infoRepository.CardInfoList.FindAll(c => c.Type_code == "investigator" && ImageListEN.Exists(x => x.name == c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo investigatorInfo in allInvestigators)
            {
                CardInvestigatorView investigatorComponent = GameObject.Instantiate(cardFactoryComponent.CardInvestigatorPrefab, cardFactoryComponent.InvestigatorsZone);
                SetData(investigatorComponent, investigatorInfo.Code);
                InvestigatorInfo investigator = investigatorRepository.AllInvestigators(investigatorInfo.Code);
                investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigatorInfo.Code);
                investigatorComponent.Investigator = investigator;
                cardViewsRepository.AllCardViews.Add(investigatorInfo.Code, investigatorComponent);
            }
        }

        private void BuildDeckCards()
        {
            var allDeckCards = infoRepository.CardInfoList.FindAll(c => (c.Type_code == "asset" || c.Type_code == "event" || c.Type_code == "skill") && ImageListEN.Exists(x => x.name == c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo card in allDeckCards)
            {
                CardDeckView cardDeckView = GameObject.Instantiate(cardFactoryComponent.CardDeckPrefab, cardFactoryComponent.DeckZone);
                SetData(cardDeckView, card.Code);
                cardViewsRepository.AllCardViews.Add(card.Code, cardDeckView);
            }
        }

        private void SetData(CardView cardComponent, string id)
        {
            CardInfo cardInfo = infoRepository.AllCardsInfo(id);
            Sprite cardSprite = GetSprite(id);
            cardComponent.Initialize(cardInfo, cardSprite);
            InjectDependency(cardComponent);
        }

        private void InjectDependency(CardView cardInstance) => diContainer.Inject(cardInstance);

        private Sprite GetSprite(string id) => ImageListEN.Find(c => c.name == id);
    }
}
