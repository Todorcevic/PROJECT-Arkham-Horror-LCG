using Arkham.Repositories;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Arkham.Factories
{
    public class CardFactory : MonoBehaviour, ICardFactory
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ICardInfoRepository infoRepository;
        [Inject] private readonly IDeckCardController cardController;
        [Inject] private readonly IInvestigatorCardController investigatorController;
        [Inject] private readonly ICardsManager cardsManager;

        [SerializeField, Required, AssetsOnly] private CardView cardPrefab;
        [SerializeField, Required, AssetsOnly] private CardView investigatorPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform cardZone;
        [SerializeField, Required, SceneObjectsOnly] private Transform investigatorZone;

        private IEnumerable<string> DeckCards => infoRepository.CardInfoList
                .FindAll(c => (c.Type_code == "asset"
                || c.Type_code == "event"
                || c.Type_code == "skill")
                && (c.Subtype_code != "basicweakness"
                && c.Subtype_code != "weakness")
                && imageCards.ExistThisSprite(c.Code)).OrderBy(c => c.Faction_code).ThenBy(c => c.Code).Select(c => c.Code);

        private IEnumerable<string> InvestigatorCards => infoRepository.CardInfoList
                .FindAll(c => c.Type_code == "investigator" && imageCards.ExistThisSprite(c.Code))
                .OrderBy(c => c.Faction_code).ThenBy(c => c.Code).Select(c => c.Code);

        /*******************************************************************/
        public void BuildDeckCards()
        {
            foreach (string cardId in DeckCards)
            {
                object[] args = new object[] { cardId, imageCards.GetSprite(cardId), cardController };
                CardView cardView = diContainer.InstantiatePrefabForComponent<CardView>(cardPrefab, cardZone, args);
                cardsManager.AddDeckCard(cardId, cardView);
            }
        }

        public void BuildInvestigatorCards()
        {
            foreach (string investigatorId in InvestigatorCards)
            {
                object[] args = new object[] { investigatorId, imageCards.GetSprite(investigatorId), investigatorController };
                CardView cardView = diContainer.InstantiatePrefabForComponent<CardView>(investigatorPrefab, investigatorZone, args);
                cardsManager.AddInvestigatorCard(investigatorId, cardView);
            }
        }
    }
}