using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Views
{
    public class PanelsManager : MonoBehaviour, IPanelsManager
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