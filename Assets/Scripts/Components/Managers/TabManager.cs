using UnityEngine;
using Arkham.UI;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Arkham.Managers
{
    public class TabManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private TabButton currentTab;
        [SerializeField, ChildGameObjectsOnly] private List<TabButton> tabButtons;

        private void Start()
        {
            foreach (TabButton tabButton in tabButtons)
            {
                tabButton.AddClickAction(() => Click(tabButton));
                tabButton.AddHoverOnAction(tabButton.HoverOnEffect);
                tabButton.AddHoverOffAction(tabButton.HoverOffEffect);
            }
            SelectTab(currentTab);
        }

        void Click(TabButton tabButton)
        {
            if (currentTab == tabButton) return;
            SelectTab(tabButton);
            tabButton.ClickEffect();
        }

        public void SelectTab(TabButton tabButton)
        {
            currentTab.HoverDesactivate();
            tabButton.HoverActivate();
            currentTab = tabButton;
        }
    }
}
