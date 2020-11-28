using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.UI;

namespace Arkham.Manager
{
    public class TabController : MonoBehaviour
    {
        [SerializeField] private TabButton currentTab;

        public TabButton CurrentTab { get => currentTab; set => currentTab = value; }

        private void Start() => SelectTab(currentTab);

        public bool IsCurrentTab(TabButton tab) => CurrentTab == tab;

        public void SelectTab(TabButton tab)
        {
            currentTab.HoverDesactivate();
            tab.HoverActivate();
            currentTab = tab;
        }
    }
}
