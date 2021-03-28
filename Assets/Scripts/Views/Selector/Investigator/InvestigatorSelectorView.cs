using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView, IInvestigatorSelectorView
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private InvestigatorSelectorEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private SelectorDragEffects dragEffects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private LeadActivator leadActivator;

        public bool IsLeader => leadActivator.IsLeader;

        /*******************************************************************/
        public void LeadIcon(bool isOn) => leadActivator.ActivateLeaderIcon(isOn);
        public void BeginDragEffect() => dragEffects.BeginningDragEffect();
        public void DraggingEffect(Vector2 movePosition) => dragEffects.DraggingEffect(movePosition);
        public void EndDragEffect() => dragEffects.EndingDragEffect();
        public void DoubleClickEffect() => effects.DoubleClickEffect();
        public void ClickEffect() => effects.ClickEffect();
        public void HoverOnEffect() => effects.HoverOnEffect();
        public void HoverOffEffect() => effects.HoverOffEffect();
        public void HoverOnAudio() => effects.HoverOnAudio();
    }
}