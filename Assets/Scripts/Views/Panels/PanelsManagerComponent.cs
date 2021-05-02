using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class PanelsManagerComponent : MonoBehaviour
    {
        private PanelView selectedPanel;
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private PanelView deafultPanel;

        /*******************************************************************/
        private void Start() => SelectPanel(deafultPanel);

        /*******************************************************************/
        public void SelectPanel(PanelView panel)
        {
            selectedPanel?.Activate(false);
            panel.Activate(true);
            selectedPanel = panel;
        }
    }
}