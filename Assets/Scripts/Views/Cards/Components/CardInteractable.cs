﻿using Arkham.Controllers;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class CardInteractable : InteractableComponent
    {
        private const float ORIGINAL_SCALE = 1.0f;
        [Title("RESOURCES")]
        [SerializeField, Required] private Transform objectToTransform;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        /*******************************************************************/
        public override void ClickEffect() => audioInteractable.ClickSound();

        public override void DoubleClickEffect() => ClickEffect();

        public override void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            objectToTransform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public override void HoverOffEffect() => objectToTransform.DOScale(ORIGINAL_SCALE, timeHoverAnimation);
    }
}