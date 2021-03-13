using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : MonoBehaviour, IInvestigatorSelectorsManager
    {
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

        public void ArrangeSelectorsAndSetThisLead(string leadInvestigatorId)
        {
            foreach (var selector in selectors)
                selector.SelectorMovement.Arrange();
            SetLeadSelector(leadInvestigatorId);
        }

        public void SetLeadSelector(string leadInvestigatorId)
        {
            if (leadInvestigatorId == GetLeadSelector.Id || leadInvestigatorId == null) return;
            GetLeadSelector.LeadActivator.ActivateLeaderIcon(false);
            GetSelectorById(leadInvestigatorId).LeadActivator.ActivateLeaderIcon(true);
        }
    }
}
