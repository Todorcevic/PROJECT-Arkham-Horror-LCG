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
    public class InvestigatorCardsManager : MonoBehaviour, IInvestigatorCardsManager
    {
        [SerializeField, Required, AssetsOnly] private InvestigatorCardView cardPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [Title("CARDS"), ShowInInspector] public List<IInvestigatorCardView> CardsList => AllCards.Values.ToList();
        public Dictionary<string, IInvestigatorCardView> AllCards { get; } =
            new Dictionary<string, IInvestigatorCardView>();
        public Transform Zone => zone;
        public InvestigatorCardView CardPrefab => cardPrefab;

        /*******************************************************************/
        public Sprite GetSpriteCard(string id) => id != null ? AllCards[id].GetCardImage : null;
    }
}
