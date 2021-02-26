using Arkham.Components;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class CampaignEffects : InteractableEffects
    {
        [SerializeField, Required] private InteractableAudio InteractableAudio;
        [SerializeField, Required] private Image chapterImage;
        [SerializeField, Required] private CanvasGroup highlighted;
        [SerializeField, Required] private Transform highlightedTextBox;

        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;
        [SerializeField, Range(0f, 100f)] private float yoffsetHoverHighlighted;
        [SerializeField, Range(1f, 2f)] private float zoomParallaxHoverEffect;

        /*******************************************************************/
        public override void ClickEffect() => InteractableAudio.ClickSound();

        public override void DoubleClickEffect() { }

        public override void HoverOnEffect()
        {
            InteractableAudio.HoverOnSound();
            chapterImage.transform.DOScale(zoomParallaxHoverEffect, timeHoverAnimation);
            highlighted.DOFade(1, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(yoffsetHoverHighlighted, timeHoverAnimation);
        }

        public override void HoverOffEffect()
        {
            InteractableAudio.HoverOffSound();
            chapterImage.transform.DOScale(1f, timeHoverAnimation);
            highlighted.DOFade(0, timeHoverAnimation);
            highlightedTextBox.transform.DOLocalMoveY(0, timeHoverAnimation);
        }
    }
}
