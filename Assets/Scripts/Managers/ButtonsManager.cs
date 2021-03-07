using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;

namespace Arkham.Managers
{
    public class ButtonsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private ButtonInteractable currentButton;

        public ButtonInteractable CurrentButton => currentButton;

        /*******************************************************************/
        private void Start()
        {
            SelectTab(currentButton);
        }

        /*******************************************************************/
        public void SelectTab(ButtonInteractable button)
        {
            currentButton?.HoverDesactivate();
            button?.HoverActivate();
            currentButton = button;
        }
    }
}
