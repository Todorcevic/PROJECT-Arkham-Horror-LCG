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

namespace Arkham.Factories
{
    public class CardFactory : ICardFactory
    {
        private readonly CardFactoryComponent cardFactoryComponent;
        private readonly Dictionary<string, Sprite> cardImage;
        private readonly Repository allData;
        private readonly CardRepository cardRepository;
        private readonly IInstanceAdapter instantiator;
        private readonly DiContainer diContainer;

        public CardFactory(CardFactoryComponent cardFactoryComponent, Repository allData, CardRepository cardRepository, DiContainer diContainer, IInstanceAdapter instantiator)
        {
            this.cardFactoryComponent = cardFactoryComponent;
            this.allData = allData;
            this.cardRepository = cardRepository;
            this.instantiator = instantiator;
            this.diContainer = diContainer;
            cardImage = BuildDictionaryImage(cardFactoryComponent);
        }

        private Dictionary<string, Sprite> BuildDictionaryImage(CardFactoryComponent cardFactoryComponent)
        {
            //TODO Check Location
            return cardFactoryComponent.CardImagesEN.ToDictionary(sprite => sprite.name);
        }

        public void BuildCards()
        {
            BuildInvestigators();
            BuildDeckCards();
        }

        private void BuildInvestigators()
        {
            var allInvestigators = allData.CardInfoList.FindAll(c => c.Type_code == "investigator" && cardImage.ContainsKey(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo investigator in allInvestigators)
            {
                CardInvestigatorView investigatorView = GameObject.Instantiate(cardFactoryComponent.CardInvestigatorPrefab, cardFactoryComponent.InvestigatorZone);
                SetData(investigatorView, investigator.Code);
                SetCardInvestigator(investigatorView, investigator.Code);
            }
        }

        private void BuildDeckCards()
        {
            var allDeckCards = allData.CardInfoList.FindAll(c => (c.Type_code == "asset" || c.Type_code == "event" || c.Type_code == "skill") && cardImage.ContainsKey(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo card in allDeckCards)
            {
                CardDeckView cardDeckView = GameObject.Instantiate(cardFactoryComponent.CardDeckPrefab, cardFactoryComponent.CardZone);
                SetData(cardDeckView, card.Code);
                SetDeckCard(cardDeckView, card.Code);
            }
        }

        private void SetData(CardView cardView, string id)
        {
            cardView.Id = id;
            cardView.name = id;
            cardView.CardImage.sprite = cardImage[id];
            InjectDependency(cardView);
        }


        private void SetCardInvestigator(CardInvestigatorView cardView, string idCard)
        {
            DeckBuildingRules deckBuildingRules = instantiator.CreateInstance<DeckBuildingRules>(idCard);
            CardInvestigator card = new CardInvestigator(idCard, cardView, deckBuildingRules);
            cardRepository.AllCardInvestigator.Add(idCard, card);
        }

        private void SetDeckCard(CardDeckView cardView, string idCard)
        {
            CardDeck card = new CardDeck(idCard, cardView);
            cardRepository.AllCardDeck.Add(idCard, card);
        }

        private void InjectDependency(CardView cardInstance) => diContainer.Inject(cardInstance);
    }
}
