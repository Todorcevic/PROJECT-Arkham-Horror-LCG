using Arkham.Components;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public class CardEffects : InteractableEffects
    {
        private const float ORIGINAL_SCALE = 1.0f;
        [SerializeField, Required] private Transform objectToTransform;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(1f, 2f)] private float scaleHoverEffect;

        /*******************************************************************/
        public override void ClickEffect() { }

        public override void DoubleClickEffect() => audioInteractable.ClickSound();

        public override void HoverOnEffect()
        {
            audioInteractable.HoverOnSound();
            objectToTransform.DOScale(scaleHoverEffect, timeHoverAnimation);
        }

        public override void HoverOffEffect() => objectToTransform.DOScale(ORIGINAL_SCALE, timeHoverAnimation);
    }
}
