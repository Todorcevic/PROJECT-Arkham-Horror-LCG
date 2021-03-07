using Arkham.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public abstract class SelectorView : ViewInteractable
    {
        private string id;
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private ImageConfigurator imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly] private GlowActivator glowActivator;

        public bool IsEmpty => Id == null;
        public Transform Transform => transform;
        public override string Id => id;
        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            id = cardId;
            imageConfigurator.Activate(cardId != null);
            imageConfigurator.ChangeImage(cardImage);
        }

        public void ActivateGlow(bool activate) => glowActivator.ActivateGlow(activate);
    }
}
