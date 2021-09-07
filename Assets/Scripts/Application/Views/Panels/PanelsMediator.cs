using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Application
{
    public class PanelsMediator : MonoBehaviour
    {
        private PanelView selectedPanel;
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private PanelView deafultPanel;

        /*******************************************************************/
        private void Start() => SelectPanel(deafultPanel);

        /*******************************************************************/
        public void SelectPanel(PanelView panel)
        {
            if (panel == selectedPanel) return;
            selectedPanel?.Activate(false);
            panel.Activate(true);
            selectedPanel = panel;
        }
    }
}