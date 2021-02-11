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
        private readonly ICardInfoRepository infoRepository;
        private readonly CardRepository cardRepository;
        private readonly IInstanceAdapter instantiator;
        private readonly DiContainer diContainer;

        public CardFactory(CardFactoryComponent cardFactoryComponent, ICardInfoRepository infoRepository, CardRepository cardRepository, DiContainer diContainer, IInstanceAdapter instantiator)
        {
            this.cardFactoryComponent = cardFactoryComponent;
            this.infoRepository = infoRepository;
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
            var allInvestigators = infoRepository.CardInfoList.FindAll(c => c.Type_code == "investigator" && cardImage.ContainsKey(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo investigator in allInvestigators)
            {
                CardInvestigatorView investigatorView = GameObject.Instantiate(cardFactoryComponent.CardInvestigatorPrefab, cardFactoryComponent.InvestigatorZone);
                SetData(investigatorView, investigator.Code);
                DeckBuildingRules deckBuildingRules = instantiator.CreateInstance<DeckBuildingRules>(investigator.Code);
                CardInvestigator cardInvestigator = new CardInvestigator(investigator.Code, investigatorView, deckBuildingRules);
                cardRepository.AllCard.Add(investigator.Code, cardInvestigator);
            }
        }

        private void BuildDeckCards()
        {
            var allDeckCards = infoRepository.CardInfoList.FindAll(c => (c.Type_code == "asset" || c.Type_code == "event" || c.Type_code == "skill") && cardImage.ContainsKey(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code);
            foreach (CardInfo card in allDeckCards)
            {
                CardDeckView cardDeckView = GameObject.Instantiate(cardFactoryComponent.CardDeckPrefab, cardFactoryComponent.CardZone);
                SetData(cardDeckView, card.Code);
                cardRepository.AllCard.Add(card.Code, new CardDeck(card.Code, cardDeckView));
            }
        }

        private void SetData(CardView cardView, string id)
        {
            cardView.Id = id;
            cardView.name = id;
            cardView.CardImage.sprite = cardImage[id];
            InjectDependency(cardView);
        }

        private void InjectDependency(CardView cardInstance) => diContainer.Inject(cardInstance);
    }
}
