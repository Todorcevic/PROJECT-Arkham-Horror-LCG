using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public class ModalPanelView : PanelView
    {
        [Title("RESOURCES")]
        [SerializeField, ChildGameObjectsOnly] private ButtonView yesButton;
        [SerializeField, ChildGameObjectsOnly] private ButtonView noButton;

        public ButtonView YesButton => yesButton;

        /*******************************************************************/
        private void OnEnable()
        {
            yesButton.ClickAction += () => Activate(false);
            noButton.ClickAction += () => Activate(false);
        }

        private void OnDisable()
        {
            yesButton.ClickAction -= () => Activate(false);
            noButton.ClickAction -= () => Activate(false);
        }
    }
}
