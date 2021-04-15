using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Views
{
    public class PanelsManager : MonoBehaviour, IPanelsManager
    {
        private IPanelView selectedPanel;
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private PanelView deafultPanel;

        /*******************************************************************/
        private void Start() => SelectPanel(deafultPanel);

        /*******************************************************************/
        public void SelectPanel(IPanelView panel)
        {
            selectedPanel?.Activate(false);
            panel.Activate(true);
            selectedPanel = panel;
        }
    }
}