using Arkham.Presenters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView, IInvestigatorSelector
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private SelectorMovement selectorMovement;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private LeadActivator leadActivator;

        public bool IsLeader => leadActivator.IsLeader;

        /*******************************************************************/
        public void MoveImageTo(Transform transform) => selectorMovement.MoveImageTo(transform);

        public void ArrangeTo(Transform transform) => selectorMovement.ArrangeTo(transform);

        public void ActivateLeaderIcon(bool activate) => leadActivator.ActivateLeaderIcon(activate);
    }
}