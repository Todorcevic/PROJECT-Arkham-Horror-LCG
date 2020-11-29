using UnityEngine;
using Arkham.UI;
using Sirenix.OdinInspector;

namespace Arkham.Manager
{
    public class TabController : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private TabButton currentTab;

        private void Start() => SelectTab(currentTab);

        public bool IsCurrentTab(TabButton tab) => currentTab == tab;

        public void SelectTab(TabButton tab)
        {
            currentTab.HoverDesactivate();
            tab.HoverActivate();
            currentTab = tab;
        }
    }
}
