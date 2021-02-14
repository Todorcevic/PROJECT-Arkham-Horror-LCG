using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.UI
{
    public class BasicButton : ButtonComponent
    {
        private void Start()
        {
            AddClickAction(ClickEffect);
            AddHoverOnAction(HoverOnEffect);
            AddHoverOffAction(HoverOffEffect);
        }

        private void ClickEffect()
        {
            audioButton.ClickSound();
            clickAction?.Invoke();
        }

        private void HoverOnEffect()
        {
            audioButton.HoverOnSound();
            HoverActivate();
        }
        private void HoverOffEffect()
        {
            audioButton.HoverOffSound();
            HoverDesactivate();
        }
    }
}
