using Arkham.Components;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Arkham.Views
{
    public class SelectorEffects : InteractableEffects
    {
        [SerializeField, Required] private Transform objectToTransform;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        /*******************************************************************/
        public override void ClickEffect() => audioInteractable.ClickSound();

        public override void DoubleClickEffect() { }

        public override void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            objectToTransform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public override void HoverOffEffect()
        {
            audioInteractable.HoverOffSound();
            objectToTransform.DOScale(1f, timeHoverAnimation);
        }
    }
}
