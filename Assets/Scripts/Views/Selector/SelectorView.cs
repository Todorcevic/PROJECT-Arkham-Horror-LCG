using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public abstract class SelectorView : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] protected ImageConfigurator imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private SelectorMovement selectorMovement;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private GlowActivator glowActivator;

        public string Id { get; protected set; }
        public bool IsEmpty => Id == null;
        public SelectorMovement SelectorMovement => selectorMovement;
        public GlowActivator GlowActivator => glowActivator;

        /*******************************************************************/
        public abstract void SetSelector(string cardId, Sprite cardImage = null);
    }
}
