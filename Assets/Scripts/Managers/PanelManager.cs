using UnityEngine;
using DG.Tweening;
using Arkham.UI;
using Sirenix.OdinInspector;

namespace Arkham.Managers
{
    public class PanelManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private PanelComponent currentPanel;

        private void Start() => SelectPanel(currentPanel);

        public void SelectPanel(PanelComponent panel)
        {
            currentPanel.Activate(false);
            panel.Activate(true);
            currentPanel = panel;
        }

        public void DisableCurrentPanel()
        {
            currentPanel.Activate(false);
        }
    }
}