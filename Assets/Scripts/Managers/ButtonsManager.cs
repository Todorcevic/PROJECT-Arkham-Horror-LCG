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
                button.Interactable.Clicked -= button.Interactable.Effects.ClickEffect;
                button.Interactable.Clicked += () => Click(button);
                button.Interactable.HoverOn -= button.Interactable.Effects.HoverOnEffect;
                button.Interactable.HoverOn += () => MantainHoverOn(button);
                button.Interactable.HoverOff -= button.Interactable.Effects.HoverOffEffect;
                button.Interactable.HoverOff += () => MantainHoverOff(button);
            }
            SelectTab(currentButton);
        }

        /*******************************************************************/
        private void Click(ButtonView button)
        {
            if (currentButton == button) return;
            button.Interactable.Effects.ClickEffect();
            SelectTab(button);
        }

        private void MantainHoverOn(ButtonView button)
        {
            if (button != currentButton)
                button.Interactable.Effects.HoverOnEffect();
        }

        private void MantainHoverOff(ButtonView button)
        {
            if (button != currentButton)
                button.Interactable.Effects.HoverOffEffect();
        }

        private void SelectTab(ButtonView button)
        {
            currentButton?.HoverDesactivate();
            button?.HoverActivate();
            currentButton = button;
        }
    }
}
