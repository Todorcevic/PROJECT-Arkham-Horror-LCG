using Arkham.Components;
using Arkham.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorView : MonoBehaviour, IInvestigatorSelectorView
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private SelectorEffects selectorEffects; //TODO: put into Interactable
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly] private SelectorMovement selectorMovement;
        [SerializeField, Required, ChildGameObjectsOnly] private GlowActivator glowActivator;
        [SerializeField, Required, ChildGameObjectsOnly] private LeadActivator leadActivator;

        public string InvestigatorInThisSelector { get; private set; }
        public bool IsEmpty => InvestigatorInThisSelector == null;
        public bool IsLead => leadActivator.IsLead;
        public InteractableComponent Interactable => interactable;
        public Transform Transform => transform;

        /*******************************************************************/
        public void Init()
        {
            interactable.Clicked += selectorEffects.ClickEffect;
            interactable.HoverOn += selectorEffects.HoverOnEffect;
            interactable.HoverOff += selectorEffects.HoverOffEffect;
        }

        public void MoveTo(Transform transform) => selectorMovement.MoveTo(transform);
        public void Arrange(Transform transform) => selectorMovement.Arrange(transform);
        public void SetInvestigator(string investigatorId, Sprite investigatorImage = null)
        {
            InvestigatorInThisSelector = investigatorId;
            imageConfigurator.Activate(investigatorId != null);
            imageConfigurator.ChangeImage(investigatorImage);
        }
        public void ActivateGlow(bool activate) => glowActivator.ActivateGlow(activate);
        public void ActivateLeader(bool activate) => leadActivator.ActivateLeader(activate);
    }
}