using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;
using Zenject;

namespace Arkham.UI
{
    public class CardFactoryComponent : MonoBehaviour
    {
        [Title("CARD PREFABS")]
        [SerializeField] private CardDeckView cardDeckPrefab;
        [SerializeField] private CardInvestigatorView cardInvestigatorPrefab;
        [SerializeField] private CardRowView cardRow;

        [Title("CARD IMAGES")]
        [SerializeField] private List<Sprite> cardImagesEN;
        [SerializeField] private List<Sprite> cardImagesES;

        [Title("ZONES")]
        [SerializeField] private Transform investigatorZone;
        [SerializeField] private Transform cardZone;

        public CardDeckView CardDeckPrefab => cardDeckPrefab;
        public CardInvestigatorView CardInvestigatorPrefab => cardInvestigatorPrefab;
        public CardRowView CardRow => cardRow;
        public List<Sprite> CardImagesEN => cardImagesEN;
        public List<Sprite> CardImagesES => cardImagesES;
        public Transform InvestigatorZone => investigatorZone;
        public Transform CardZone => cardZone;
    }
}
