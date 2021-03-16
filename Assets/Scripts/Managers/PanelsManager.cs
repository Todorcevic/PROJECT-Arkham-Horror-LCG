using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;

namespace Arkham.Managers
{
    public class PanelsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private PanelComponent currentPanel;

        /*******************************************************************/
        private void Start() => SelectPanel(currentPanel);

        /*******************************************************************/
        public void SelectPanel(PanelComponent panel)
        {
            currentPanel.Activate(false);
            panel.Activate(true);
            currentPanel = panel;
        }
    }
}