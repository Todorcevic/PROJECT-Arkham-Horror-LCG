using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;
using Zenject;

namespace Arkham.Managers
{
    public class PanelsManager : MonoBehaviour, IInitializable
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private PanelComponent currentPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => SelectPanel(currentPanel);

        /*******************************************************************/
        public void SelectPanel(PanelComponent panel)
        {
            currentPanel.Activate(false);
            panel.Activate(true);
            currentPanel = panel;
        }
    }
}