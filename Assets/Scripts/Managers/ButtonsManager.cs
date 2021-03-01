using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Arkham.Views;
using Zenject;

namespace Arkham.Managers
{
    public class ButtonsManager : MonoBehaviour, IInitializable
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private ButtonInteractable currentButton;
        [SerializeField, ChildGameObjectsOnly] private List<ButtonInteractable> buttons;

        /*******************************************************************/

        void IInitializable.Initialize()
        {
            foreach (ButtonInteractable button in buttons)
            {
                button.Clicked -= button.ClickEffect;
                button.DoubleClicked -= button.DoubleClickEffect;
                button.HoverOn -= button.HoverOnEffect;
                button.HoverOff -= button.HoverOffEffect;
                button.Clicked += () => Click(button);
                button.HoverOn += () => MantainHoverOn(button);
                button.HoverOff += () => MantainHoverOff(button);
            }
            SelectTab(currentButton);
        }

        /*******************************************************************/
        private void Click(ButtonInteractable button)
        {
            if (currentButton == button) return;
            button.ClickEffect();
            SelectTab(button);
        }

        private void MantainHoverOn(ButtonInteractable button)
        {
            if (button != currentButton)
                button.HoverOnEffect();
        }

        private void MantainHoverOff(ButtonInteractable button)
        {
            if (button != currentButton)
                button.HoverOffEffect();
        }

        private void SelectTab(ButtonInteractable button)
        {
            currentButton?.HoverDesactivate();
            button?.HoverActivate();
            currentButton = button;
        }
    }
}
