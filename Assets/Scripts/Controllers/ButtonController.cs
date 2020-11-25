using UnityEngine;
using Arkham.UI;

namespace Arkham.Controller
{
    public class ButtonController : IButtonController
    {
        public void Click(ButtonComponent button) => button.PlaySound(button.ClickSound);

        public void HoverEnter(ButtonComponent button)
        {
            button.PlaySound(button.HoverEnterSound);
            button.ChangeTextColor(button.HoverColor);
            button.FillBackground(true);
        }

        public void HoverExit(ButtonComponent button)
        {
            button.PlaySound(button.HoverExitSound);
            button.ChangeTextColor(button.SimpleColor);
            button.FillBackground(false);
        }
    }
}