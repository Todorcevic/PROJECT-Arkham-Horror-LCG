using UnityEngine;
using DG.Tweening;
using Arkham.UI;

namespace Arkham.Manager
{
    public class PanelManager : MonoBehaviour
    {
        [Header("RESOURCES")]
        [SerializeField] protected PanelComponent currentPanel;

        private void Start() => SelectPanel(currentPanel);

        public virtual void SelectPanel(PanelComponent panel)
        {
            if (currentPanel != null) currentPanel.Desactivate();
            panel.Activate();
            currentPanel = panel;
        }
    }
}