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
            PlaySound(clickSound);
            clickAction?.Invoke();
        }

        public void HoverOnEffect()
        {
            PlaySound(hoverEnterSound);
            HoverActivate();
        }
        public void HoverOffEffect()
        {
            PlaySound(hoverExitSound);
            HoverDesactivate();
        }
    }
}