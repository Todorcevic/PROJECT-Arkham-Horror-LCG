using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Arkham.Model;
using Arkham.UI;
using System;
using Zenject;
using Arkham.Investigators;
using Arkham.Adapters;
using System.Runtime.Remoting;

namespace Arkham.Factories
{
    public class CardFactory : ICardFactory
    {
        private readonly CardFactoryComponent cardFactoryComponent;
        private readonly Dictionary<string, Sprite> cardImage;
        private readonly GameData gameData;
        private readonly PlayerData playerData;
        private readonly IInstanceAdapter instantiator;

        public CardFactory(CardFactoryComponent cardFactoryComponent, GameData gameData, PlayerData playerData, IInstanceAdapter instantiator)
        {
            this.cardFactoryComponent = cardFactoryComponent;
            this.gameData = gameData;
            this.playerData = playerData;
            this.instantiator = instantiator;
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
            var allInvestigators = gameData.AllDataCards
                .Where(c => c.Type_code == "investigator" && cardImage.ContainsKey(c.Code))
                .OrderBy(c => c.Faction_code);
            foreach (Card investigator in allInvestigators)
            {
                cardFactoryComponent.CardHPrefab.Info = investigator;
                cardFactoryComponent.CardHPrefab.name = investigator.Code;
                cardFactoryComponent.CardHPrefab.CardImage.sprite = cardImage[investigator.Code];
                cardFactoryComponent.CardHPrefab.Investigator = playerData.AllInvestigatorsDictionary[investigator.Code];
                cardFactoryComponent.CardHPrefab.Investigator.DeckBuilding = instantiator.CreateInstance<DeckBuildingRules>(investigator.Code);
                GameObject.Instantiate(cardFactoryComponent.CardHPrefab, cardFactoryComponent.InvestigatorZone);
            }
        }

        private void BuildDeckCards()
        {
            var allDeckCards = gameData.AllDataCards
                .Where(c => (c.Type_code == "asset" || c.Type_code == "event" || c.Type_code == "skill") && cardImage.ContainsKey(c.Code))
                .OrderBy(c => c.Faction_code);
            foreach (Card card in allDeckCards)
            {
                cardFactoryComponent.CardVPrefab.Info = card;
                cardFactoryComponent.CardVPrefab.name = card.Code;
                cardFactoryComponent.CardVPrefab.CardImage.sprite = cardImage[card.Code];
                GameObject.Instantiate(cardFactoryComponent.CardVPrefab, cardFactoryComponent.CardZone);
            }
        }


    }
}
