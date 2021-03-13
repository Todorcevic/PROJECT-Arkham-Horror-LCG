using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : SelectorView
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private InvestigatorSelectorEffects effects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private InvestigatorSelectorDragEffects dragEffects;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private LeadActivator leadActivator;

        public InvestigatorSelectorEffects Effects => effects;
        public InvestigatorSelectorDragEffects DragEffects => dragEffects;
        public LeadActivator LeadActivator => leadActivator;

        /*******************************************************************/
        public override void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = cardId;
            imageConfigurator.ChangeImage(cardImage);
        }
    }
}