using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Views;

namespace Arkham.Managers
{
    public class ButtonsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private ButtonEffects currentButton;

        public ButtonEffects CurrentButton => currentButton;

        /*******************************************************************/
        private void Start()
        {
            SelectTab(currentButton);
        }

        /*******************************************************************/
        public void SelectTab(ButtonEffects button)
        {
            currentButton?.HoverDesactivate();
            button?.HoverActivate();
            currentButton = button;
        }
    }
}
