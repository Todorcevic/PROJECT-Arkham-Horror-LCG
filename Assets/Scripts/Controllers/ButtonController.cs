using Arkham.UI;

namespace Arkham.Controller
{
    public class ButtonController : IButtonController
    {
        private readonly ButtonComponent button;

        public ButtonController(ButtonComponent button) => this.button = button;

        public void Click()
        {
            button.PlaySound(button.ClickSound);
            button.ClickAction.Invoke();
        }

        public void HoverEnter()
        {
            button.PlaySound(button.HoverEnterSound);
            button.ChangeTextColor(button.HoverColor);
            button.FillBackground(true);
        }

        public void HoverExit()
        {
            button.PlaySound(button.HoverExitSound);
            button.ChangeTextColor(button.SimpleColor);
            button.FillBackground(false);
        }
    }
}