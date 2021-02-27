using Arkham.Views;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public class DeckCardsManager : MonoBehaviour, IDeckCardsManager
    {
        [SerializeField, Required, AssetsOnly] private DeckCardView cardPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [Title("CARDS"), ShowInInspector] public List<IDeckCardView> CardsList => AllCards.Values.ToList();
        public Dictionary<string, IDeckCardView> AllCards { get; } =
            new Dictionary<string, IDeckCardView>();
        public Transform Zone => zone;
        public DeckCardView CardPrefab => cardPrefab;

        /*******************************************************************/
        public Sprite GetSpriteCard(string id) => id != null ? AllCards[id].GetCardImage : null;
    }
}
