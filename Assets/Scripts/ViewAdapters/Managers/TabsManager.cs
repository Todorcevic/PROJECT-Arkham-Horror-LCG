using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;

namespace Arkham.Managers
{
    public class TabsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private ButtonView currentButton;

        /*******************************************************************/
        private void Start() => SelectTab(currentButton);

        /*******************************************************************/
        public void SelectTab(ButtonView button)
        {
            currentButton.Lock(false);
            button.Lock(true);
            currentButton = button;
        }
    }
}
