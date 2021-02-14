using UnityEngine;
using UnityEngine.EventSystems;
using Arkham.Managers;
using Sirenix.OdinInspector;
using System;

namespace Arkham.UI
{
    public class TabButton : ButtonComponent
    {
        public void ClickEffect()
        {
            audioButton.ClickSound();
            clickAction?.Invoke();
        }

        public void HoverOnEffect()
        {
            audioButton.HoverOnSound();
            HoverActivate();
        }
        public void HoverOffEffect()
        {
            audioButton.HoverOffSound();
            HoverDesactivate();
        }
    }
}