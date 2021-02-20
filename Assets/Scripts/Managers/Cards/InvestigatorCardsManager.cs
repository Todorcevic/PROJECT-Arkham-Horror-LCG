using Arkham.Interactors;
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
    public class InvestigatorCardsManager : MonoBehaviour, IInvestigatorCardsManager
    {
        [SerializeField, Required, AssetsOnly] private InvestigatorCardView investigatorCardPrefab;
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [Title("CARDS"), ShowInInspector] public List<IInvestigatorCardView> InvestigatorCardsList => AllInvestigatorCards.Values.ToList();
        public Dictionary<string, IInvestigatorCardView> AllInvestigatorCards { get; } =
            new Dictionary<string, IInvestigatorCardView>();
        public Transform Zone => zone;
        public InvestigatorCardView InvestigatorCardPrefab => investigatorCardPrefab;

        /*******************************************************************/
        public Sprite GetSpriteCard(string id) => AllInvestigatorCards[id].GetCardImage;
    }
}
