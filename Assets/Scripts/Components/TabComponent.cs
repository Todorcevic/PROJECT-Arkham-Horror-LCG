using Arkham.Controller;

namespace Arkham.UI
{
    public class TabComponent : ButtonComponent
    {
        private void Awake() => controller = new TabController(this);

        public void Click() => controller.Click();

        public void Activate()
        {
            ChangeTextColor(HoverColor);
            FillBackground(true);
        }

        public void Desactivate()
        {
            ChangeTextColor(SimpleColor);
            FillBackground(false);
        }
    }
}