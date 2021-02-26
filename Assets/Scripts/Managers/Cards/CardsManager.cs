using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class CardsManager : MonoBehaviour, ICardsManager
    {
        [SerializeField, Required, AssetsOnly] private CardView cardPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [Title("CARDS"), ShowInInspector] public List<ICardView> CardsList => AllCards.Values.ToList();
        public Dictionary<string, ICardView> AllCards { get; } =
            new Dictionary<string, ICardView>();
        public Transform Zone => zone;
        public CardView CardPrefab => cardPrefab;

        /*******************************************************************/
        public Sprite GetSpriteCard(string id) => id != null ? AllCards[id].GetCardImage : null;
    }
}
