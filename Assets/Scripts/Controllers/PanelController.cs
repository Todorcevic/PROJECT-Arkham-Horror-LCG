using UnityEngine;
using DG.Tweening;
using Arkham.UI;
using Sirenix.OdinInspector;

namespace Arkham.Manager
{
    public class PanelController : MonoBehaviour
    {
        [Header("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] protected PanelComponent currentPanel;

        private void Start() => SelectPanel(currentPanel);

        public virtual void SelectPanel(PanelComponent panel)
        {
            currentPanel.Activate(false);
            panel.Activate(true);
            currentPanel = panel;
        }
    }
}