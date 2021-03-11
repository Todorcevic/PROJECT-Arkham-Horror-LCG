using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class SelectorView : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private ImageConfigurator imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")]
        private GlowActivator glowActivator;

        public string Id { get; private set; }
        public bool IsEmpty => Id == null;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = cardId;
            imageConfigurator.ChangeImage(cardImage);
        }

        public void ActivateGlow(bool activate) => glowActivator.ActivateGlow(activate);
    }
}
