using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using Arkham.Managers;
using Arkham.Controllers;
using Arkham.Components;
using Arkham.Views;

namespace Arkham.UI
{
    public class CardFactoryComponent : MonoBehaviour, ICardFactoryComponents
    {
        [Title("CARD PREFABS")]
        [SerializeField, Required, AssetsOnly] private DeckCardView cardDeckPrefab;
        [SerializeField, Required, AssetsOnly] private InvestigatorCardView cardInvestigatorPrefab;

        [Title("CARD IMAGES")]
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesEN;
        [SerializeField, AssetsOnly] private List<Sprite> cardImagesES;

        [Title("ZONES")]
        [SerializeField, Required, SceneObjectsOnly] private Transform investigatorsZone;
        [SerializeField, Required, SceneObjectsOnly] private Transform deckZone;

        public DeckCardView CardDeckPrefab => cardDeckPrefab;
        public InvestigatorCardView CardInvestigatorPrefab => cardInvestigatorPrefab;
        public List<Sprite> CardImagesEN => cardImagesEN;
        public List<Sprite> CardImagesES => cardImagesES;
        public Transform InvestigatorsZone => investigatorsZone;
        public Transform DeckZone => deckZone;
    }
}
