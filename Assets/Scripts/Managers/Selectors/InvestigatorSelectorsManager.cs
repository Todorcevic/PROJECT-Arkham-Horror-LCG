using Arkham.Repositories;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : MonoBehaviour, IInvestigatorSelectorsManager
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHoldersZone;
        [SerializeField, Required, SceneObjectsOnly] private List<InvestigatorSelectorView> selectors;

        public Transform PlaceHoldersZone => placeHoldersZone;
        public List<InvestigatorSelectorView> Selectors => selectors;
        public InvestigatorSelectorView GetLeadSelector => selectors.Find(i => i.LeadActivator.IsLeader);

        /*******************************************************************/
        public InvestigatorSelectorView GetEmptySelector() => Selectors.Find(selector => selector.Id == null);

        public InvestigatorSelectorView GetSelectorById(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId);
    }
}
