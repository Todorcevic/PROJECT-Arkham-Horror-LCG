using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;

namespace Arkham.Managers
{
    public class TabsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private TabButtonView currentButton;

        /*******************************************************************/
        private void Start() => SelectTab(currentButton);

        /*******************************************************************/
        public void SelectTab(TabButtonView button)
        {
            currentButton.IsInactive = false;
            currentButton.HoverDesactive();
            button.IsInactive = true;
            button.HoverActive();
            currentButton = button;
        }
    }
}
