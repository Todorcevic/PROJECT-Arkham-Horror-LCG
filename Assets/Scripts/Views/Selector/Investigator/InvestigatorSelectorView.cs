using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private InvestigatorSelectorEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private SelectorDragEffects dragEffects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private LeadActivator leadActivator;

        public InvestigatorSelectorEffects Effects => effects;
        public SelectorDragEffects DragEffects => dragEffects;
        public LeadActivator LeadActivator => leadActivator;
    }
}