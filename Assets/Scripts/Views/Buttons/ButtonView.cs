using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Arkham.Components;

namespace Arkham.View
{
    public class ButtonView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private ButtonEffects buttonEffects;

        [Title("CLICK EVENT")]
        [SerializeField] protected UnityEvent clickAction;

        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        private void Start()
        {
            interactable.Init();
            interactable.Clicked += () => clickAction?.Invoke();
        }

        /*******************************************************************/
        public void HoverActivate() => buttonEffects.HoverActivate();
        public void HoverDesactivate() => buttonEffects.HoverDesactivate();
    }
}