using Arkham.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public abstract class SelectorView : MonoBehaviour, IViewInteractable
    {
        [Inject] private readonly IController controller;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactableComponent;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly] private GlowActivator glowActivator;

        public abstract IInteractableEffects InteractableEffects { get; }
        public string Id { get; private set; }
        public bool IsEmpty => Id == null;
        public Transform Transform => transform;

        /*******************************************************************/
        private void Start()
        {
            interactableComponent.Init(this, controller);
        }

        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = cardId;
            imageConfigurator.Activate(cardId != null);
            imageConfigurator.ChangeImage(cardImage);
        }

        public void ActivateGlow(bool activate) => glowActivator.ActivateGlow(activate);
    }
}
