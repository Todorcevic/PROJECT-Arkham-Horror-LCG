using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;
using Zenject;
using Arkham.Managers;

namespace Arkham.UI
{
    public class CardFactoryComponent : MonoBehaviour
    {
        [Title("CARD PREFABS")]
        [SerializeField, Required, AssetsOnly] private CardDeckComponent cardDeckPrefab;
        [SerializeField, Required, AssetsOnly] private CardInvestigatorComponent cardInvestigatorPrefab;
        [SerializeField, Required, AssetsOnly] private CardRowView cardRow;

        [Title("CARD IMAGES")]
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesEN;
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesES;

        [Title("ZONES")]
        [SerializeField, Required, SceneObjectsOnly] private Transform investigatorsZone;
        [SerializeField, Required, SceneObjectsOnly] private Transform deckZone;

        public CardDeckComponent CardDeckPrefab => cardDeckPrefab;
        public CardInvestigatorComponent CardInvestigatorPrefab => cardInvestigatorPrefab;
        public CardRowView CardRow => cardRow;
        public List<Sprite> CardImagesEN => cardImagesEN;
        public List<Sprite> CardImagesES => cardImagesES;
        public Transform InvestigatorsZone => investigatorsZone;
        public Transform DeckZone => deckZone;
    }
}
