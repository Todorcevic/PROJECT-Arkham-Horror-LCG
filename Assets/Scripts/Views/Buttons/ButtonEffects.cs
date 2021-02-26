using Arkham.Components;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.View
{
    public class ButtonEffects : InteractableEffects
    {
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private TextMeshProUGUI text;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        /*******************************************************************/
        public override void ClickEffect() => interactableAudio.ClickSound();

        public override void DoubleClickEffect() { }

        public override void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate();
        }

        public override void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverDesactivate();
        }

        public void HoverActivate()
        {
            ChangeTextColor(Color.black);
            FillBackground(true);
        }

        public void HoverDesactivate()
        {
            ChangeTextColor(Color.white);
            FillBackground(false);
        }

        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);
        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}