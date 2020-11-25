using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.UI;

namespace Arkham.Controller
{
    public class TabController : IButtonController
    {
        private static TabComponent currentTab;

        public void Click(ButtonComponent tab)
        {
            TabComponent tabb = (TabComponent)tab;
            if (currentTab == tabb) return;
            tabb.PlaySound(tabb.ClickSound);
            Selected(tabb);
        }

        public void HoverEnter(ButtonComponent tab)
        {
            TabComponent tabb = (TabComponent)tab;
            if (currentTab == tabb) return;
            tabb.PlaySound(tabb.HoverEnterSound);
            Activate(tabb);
        }

        public void HoverExit(ButtonComponent tab)
        {
            TabComponent tabb = (TabComponent)tab;
            if (currentTab == tabb) return;
            Desactivate(tabb);
        }

        void Selected(TabComponent tab)
        {
            if (currentTab != null) Desactivate(currentTab);
            Activate(tab);
            currentTab = tab;
        }

        void Activate(TabComponent tab)
        {
            tab.ChangeTextColor(tab.HoverColor);
            tab.FillBackground(true);
        }

        void Desactivate(TabComponent tab)
        {
            tab.ChangeTextColor(tab.SimpleColor);
            tab.FillBackground(false);
        }
    }
}
