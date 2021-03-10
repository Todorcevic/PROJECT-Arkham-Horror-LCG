using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;

namespace Arkham.Managers
{
    public class ButtonsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private ButtonView currentButton;

        /*******************************************************************/
        private void Start() => SelectTab(currentButton);

        /*******************************************************************/
        public void SelectTab(ButtonView button)
        {
            currentButton.IsActive = true;
            currentButton.ButtonEffects.HoverDesactivate();
            button.IsActive = false;
            button.ButtonEffects.HoverActivate();
            currentButton = button;
        }
    }
}
