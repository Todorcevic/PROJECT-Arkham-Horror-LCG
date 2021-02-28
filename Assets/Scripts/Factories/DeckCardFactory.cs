using Arkham.Components;
using Arkham.Controllers;
using Arkham.Managers;
using Arkham.Models;
using Arkham.Presenters;
using Arkham.Repositories;
using Arkham.Views;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Factories
{
    public class DeckCardFactory : IDeckCardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ICardInfoRepository infoRepository;
        [Inject] private readonly IDeckCardsManager deckCardsManager;
        [Inject] private readonly IDeckCardController deckCardController;
        [Inject] private readonly IDeckCardPresenter deckCardPresenter;

        /*******************************************************************/
        public void BuildDeckCards()
        {
            var allDeckCards = infoRepository.CardInfoList
                .FindAll(c => (c.Type_code == "asset"
                || c.Type_code == "event"
                || c.Type_code == "skill")
                && (c.Subtype_code != "basicweakness"
                && c.Subtype_code != "weakness")
                && imageCards.ExistThisSprite(c.Code)).OrderBy(c => c.Faction_code).ThenBy(c => c.Code);

            foreach (CardInfo card in allDeckCards)
                Create(card.Code, deckCardsManager, deckCardController);

            deckCardPresenter.Init();
        }

        private void Create(string cardId, IDeckCardsManager manager, ICardController controller)
        {
            var args = new object[] { cardId, imageCards.GetSprite(cardId) };
            DeckCardView cardView =
                diContainer.InstantiatePrefabForComponent<DeckCardView>(manager.CardPrefab, manager.Zone, args);
            manager.AllCards.Add(cardId, cardView);
            controller.Init(cardView);
        }
    }
}
