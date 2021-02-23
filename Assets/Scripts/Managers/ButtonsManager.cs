using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Arkham.Components;
using Arkham.View;

namespace Arkham.Managers
{
    public class ButtonsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private ButtonView currentButton;
        [SerializeField, ChildGameObjectsOnly] private List<ButtonView> buttons;

        /*******************************************************************/
        private void Start()
        {
            foreach (ButtonView button in buttons)
            {
                button.Interactable.Clicked -= button.ClickEffect;
                button.Interactable.Clicked += () => Click(button);
                button.Interactable.HoverOn -= button.HoverOnEffect;
                button.Interactable.HoverOn += () => MantainHoverOn(button);
                button.Interactable.HoverOff -= button.HoverOffEffect;
                button.Interactable.HoverOff += () => MantainHoverOff(button);
            }
            SelectTab(currentButton);
        }

        /*******************************************************************/
        private void Click(ButtonView button)
        {
            if (currentButton == button) return;
            button.ClickEffect();
            SelectTab(button);
        }

        private void MantainHoverOn(ButtonView button)
        {
            if (button != currentButton)
                button.HoverOnEffect();
        }

        private void MantainHoverOff(ButtonView button)
        {
            if (button != currentButton)
                button.HoverOffEffect();
        }

        private void SelectTab(ButtonView button)
        {
            currentButton?.HoverDesactivate();
            button?.HoverActivate();
            currentButton = button;
        }
    }
}
