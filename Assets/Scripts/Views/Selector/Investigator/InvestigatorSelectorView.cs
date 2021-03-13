using Arkham.Presenters;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private InvestigatorSelectorEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private InvestigatorSelectorDragEffects dragEffects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private SelectorMovement selectorMovement;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private LeadActivator leadActivator;

        public InvestigatorSelectorEffects Effects => effects;
        public InvestigatorSelectorDragEffects DragEffects => dragEffects;
        public SelectorMovement SelectorMovement => selectorMovement;
        public LeadActivator LeadActivator => leadActivator;
    }
}