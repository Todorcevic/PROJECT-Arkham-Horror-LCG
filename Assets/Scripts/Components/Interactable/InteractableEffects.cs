using UnityEngine;

namespace Arkham.Components
{
    public abstract class InteractableEffects : MonoBehaviour
    {
        public abstract void ClickEffect();
        public abstract void DoubleClickEffect();
        public abstract void HoverOnEffect();
        public abstract void HoverOffEffect();
    }
}
