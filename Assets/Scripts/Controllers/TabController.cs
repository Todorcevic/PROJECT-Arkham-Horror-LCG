using Arkham.UI;

namespace Arkham.Controller
{
    public class TabController : IButtonController
    {
        private static TabComponent currentTab;
        private readonly TabComponent tab;

        public TabController(TabComponent tab) => this.tab = tab;

        public void Click()
        {
            if (currentTab == tab) return;
            tab.PlaySound(tab.ClickSound);
            Selected();
            tab.ClickAction.Invoke();
        }

        public void HoverEnter()
        {
            if (currentTab == tab) return;
            tab.PlaySound(tab.HoverEnterSound);
            tab.Activate();
        }

        public void HoverExit()
        {
            if (currentTab == tab) return;
            tab.Desactivate();
        }

        void Selected()
        {
            if (currentTab != null) currentTab.Desactivate();
            tab.Activate();
            currentTab = tab;
        }
    }
}