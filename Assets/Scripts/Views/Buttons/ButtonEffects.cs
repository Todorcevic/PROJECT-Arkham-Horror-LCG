using Arkham.Components;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.View
{
    public class ButtonEffects : MonoBehaviour
    {
        private Color simpleTextColor = Color.white;
        private Color hoverTextColor = Color.black;

        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio interactableAudio;
        [SerializeField, Required] private Image background;
        [SerializeField, Required] private TextMeshProUGUI text;
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        /*******************************************************************/
        public void ClickEffect() => interactableAudio.ClickSound();

        public void HoverOnEffect()
        {
            interactableAudio.HoverOnSound();
            HoverActivate();
        }
        public void HoverOffEffect()
        {
            interactableAudio.HoverOffSound();
            HoverDesactivate();
        }

        public void HoverActivate()
        {
            ChangeTextColor(hoverTextColor);
            FillBackground(true);
        }

        public void HoverDesactivate()
        {
            ChangeTextColor(simpleTextColor);
            FillBackground(false);
        }

        private void ChangeTextColor(Color color) => text.DOColor(color, timeHoverAnimation);
        private void FillBackground(bool toFill) => background.DOFillAmount(toFill ? 1 : 0, timeHoverAnimation);
    }
}