using Arkham.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView, IInvestigatorSelectorView
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private LeadActivator leadActivator;

        public bool IsLead => leadActivator.IsLead;

        /*******************************************************************/
        public void ActivateLeaderIcon(bool activate) => leadActivator.ActivateLeaderIcon(activate);
    }
}