using Arkham.Presenters;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class CardsManager : MonoBehaviour
    {
        [SerializeField, Required, AssetsOnly] private CardView cardPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [Title("CARDS"), ShowInInspector] public List<ICardVisualizable> CardsList => AllCards.Values.ToList();

        public Dictionary<string, ICardVisualizable> AllCards { get; } =
            new Dictionary<string, ICardVisualizable>();
        public Transform Zone => zone;
        public CardView CardPrefab => cardPrefab;

        /*******************************************************************/
        public Sprite GetSpriteCard(string id) => id != null ? AllCards[id].GetCardImage : null;
    }
}
