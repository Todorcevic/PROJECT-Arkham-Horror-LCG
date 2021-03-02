using Arkham.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class SelectorView : MonoBehaviour, IInteractableView
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly] private GlowActivator glowActivator;
        public string Id { get; private set; }
        public bool IsEmpty => Id == null;
        public InteractableComponent Interactable => interactable;
        public Transform Transform => transform;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = cardId;
            imageConfigurator.Activate(cardId != null);
            imageConfigurator.ChangeImage(cardImage);
        }

        public void ActivateGlow(bool activate) => glowActivator.ActivateGlow(activate);
    }
}
