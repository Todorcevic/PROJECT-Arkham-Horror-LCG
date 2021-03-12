using Arkham.Presenters;
using Sirenix.OdinInspector;
using System;
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
        public Transform PlaceHolder => selectorMovement.PlaceHolder;

        /*******************************************************************/
        public void MoveImageTo(Transform transform) => selectorMovement.MoveImageTo(transform);

        public void SetTransform(Transform transform) => selectorMovement.SetTransform(transform);

        public void ArrangeTo() => StartCoroutine(selectorMovement.ArrangeTo());

        public void ActivateLeaderIcon(bool activate) => leadActivator.ActivateLeaderIcon(activate);

        public void SwapPlaceHolder(Transform selectorDragging) => selectorMovement.SwapPlaceHolder(selectorDragging);
    }
}