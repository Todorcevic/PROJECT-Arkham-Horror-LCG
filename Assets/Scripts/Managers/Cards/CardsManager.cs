using Arkham.Repositories;
using Arkham.Views;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public abstract class CardsManager : MonoBehaviour
    {
        [SerializeField, Required, AssetsOnly] private CardView cardPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [Title("CARDS"), ShowInInspector] public List<ICardView> CardsList => AllCards.Values.ToList();
        public Dictionary<string, ICardView> AllCards { get; } =
            new Dictionary<string, ICardView>();
        public Transform Zone => zone;
        public CardView CardPrefab => cardPrefab;

        /*******************************************************************/
        public Sprite GetSpriteCard(string id) => AllCards[id].GetCardImage;
    }
}
