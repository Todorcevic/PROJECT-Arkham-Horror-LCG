using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;
using Arkham.ScriptableObjects;
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
            interactable.Clicked += ClickEffect;
            interactable.HoverOn += HoverOnEffect;
            interactable.HoverOff += HoverOffEffect;
        }

        /*******************************************************************/
        public void ClickEffect()
        {
            buttonEffects.ClickEffect();
            clickAction?.Invoke();
        }

        public void HoverOnEffect() => buttonEffects.HoverOnEffect();
        public void HoverOffEffect() => buttonEffects.HoverOffEffect();
        public void HoverActivate() => buttonEffects.HoverActivate();
        public void HoverDesactivate() => buttonEffects.HoverDesactivate();
    }
}