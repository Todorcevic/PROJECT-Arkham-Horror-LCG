using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView, IInvestigatorSelector
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private LeadActivator leadActivator;
        [SerializeField, Required, ChildGameObjectsOnly] private SelectorMovement selectorMovement;
        public bool IsLeader => leadActivator.IsLeader;

        /*******************************************************************/
        public void MoveTo(Transform transform) => selectorMovement.MoveTo(transform);
        public void Arrange(Transform transform) => selectorMovement.Arrange(transform);
        public void ActivateLeaderIcon(bool activate) => leadActivator.ActivateLeaderIcon(activate);
    }
}