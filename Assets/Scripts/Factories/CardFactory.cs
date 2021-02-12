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
        [Inject] private readonly IInvestigatorsZone investigatorsZone;
        [Inject] private readonly IDeckZone deckZone;
        [Inject] private readonly ICardInfoRepository infoRepository;
        [Inject] private readonly ICardViewsRepository cardViewsRepository;
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
            foreach (CardInfo investigator in allInvestigators)
            {
                CardInvestigatorView investigatorView = GameObject.Instantiate(cardFactoryComponent.CardInvestigatorPrefab, cardFactoryComponent.InvestigatorsZone);
                SetData(investigatorView, investigator.Code);
                DeckBuildingRules deckBuildingRules = instantiator.CreateInstance<DeckBuildingRules>(investigator.Code);
                investigatorsZone.InvestigatorsCards.Add(investigator.Code, investigatorView);
                cardViewsRepository.AllCardViews.Add(investigator.Code, investigatorView);
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
                deckZone.InvestigatorsCards.Add(card.Code, cardDeckView);
                cardViewsRepository.AllCardViews.Add(card.Code, cardDeckView);
            }
        }

        private void SetData(CardView cardView, string id)
        {
            cardView.Id = id;
            cardView.name = id;
            cardView.CardImage.sprite = GetSprite(id);
            InjectDependency(cardView);
        }

        private void InjectDependency(CardView cardInstance) => diContainer.Inject(cardInstance);

        private Sprite GetSprite(string id) => ImageListEN.Find(c => c.name == id);
    }
}
