using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Model;
using Zenject;

namespace Arkham.UI
{
    public class CardFactoryComponent : MonoBehaviour
    {
        [Title("CARD PREFABS")]
        [SerializeField] private CardVComponent cardVPrefab;
        [SerializeField] private CardHComponent cardHPrefab;
        [SerializeField] private CardRowComponent cardRow;

        [Title("CARD IMAGES")]
        [SerializeField] private List<Sprite> cardImagesEN;
        [SerializeField] private List<Sprite> cardImagesES;

        [Title("ZONES")]
        [SerializeField] private Transform investigatorZone;
        [SerializeField] private Transform cardZone;

        public CardVComponent CardVPrefab => cardVPrefab;
        public CardHComponent CardHPrefab => cardHPrefab;
        public CardRowComponent CardRow => cardRow;
        public List<Sprite> CardImagesEN => cardImagesEN;
        public List<Sprite> CardImagesES => cardImagesES;
        public Transform InvestigatorZone => investigatorZone;
        public Transform CardZone => cardZone;
    }
}
