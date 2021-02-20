using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class DeckCardsManager : MonoBehaviour, IDeckCardsManager
    {
        [SerializeField, Required, AssetsOnly] private DeckCardView deckCardPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [Title("CARDS"), ShowInInspector] public List<IDeckCardView> DeckCardsList => AllDeckCards.Values.ToList();
        public Dictionary<string, IDeckCardView> AllDeckCards { get; } =
            new Dictionary<string, IDeckCardView>();
        public Transform Zone => zone;
        public DeckCardView DeckCardPrefab => deckCardPrefab;

        /*******************************************************************/
        public Sprite GetSpriteCard(string id) => AllDeckCards[id].GetCardImage;
    }
}
