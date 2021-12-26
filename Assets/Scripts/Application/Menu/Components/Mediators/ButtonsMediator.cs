using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public class ButtonsMediator : MonoBehaviour
    {
        private ButtonView currentButton;
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private List<ButtonView> buttons;

        private ButtonView FirstButton => buttons[0];

        /*******************************************************************/
        private void Awake() => buttons.ForEach(button => button.ClickAction += () => SelectButton(button));

        private void Start() => SelectButton(FirstButton);

        /*******************************************************************/
        private void SelectButton(ButtonView button)
        {
            currentButton?.Lock(false);
            button.Lock(true);
            currentButton = button;
        }
    }
}
