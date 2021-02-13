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
            PlaySound(clickSound);
            clickAction?.Invoke();
        }

        private void HoverOnEffect()
        {
            PlaySound(hoverEnterSound);
            HoverActivate();
        }
        private void HoverOffEffect()
        {
            PlaySound(hoverExitSound);
            HoverDesactivate();
        }
    }
}
