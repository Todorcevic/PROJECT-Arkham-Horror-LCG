using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Arkham.Components;

namespace Arkham.Managers
{
    public class ButtonsManager : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private ButtonComponent currentButton;
        [SerializeField, ChildGameObjectsOnly] private List<ButtonComponent> buttons;

        /*******************************************************************/
        private void Start()
        {
            foreach (ButtonComponent button in buttons)
            {
                button.Interactable.AddClickAction(() => Click(button));
                button.Interactable.RemoveHoverOffAction(button.HoverOffEffect);
                button.Interactable.AddHoverOffAction(() => MantainHover(button));
            }
            SelectTab(currentButton);
        }

        /*******************************************************************/
        private void Click(ButtonComponent button)
        {
            if (currentButton == button) return;
            SelectTab(button);
        }

        private void MantainHover(ButtonComponent button)
        {
            if (button != currentButton) button.HoverOffEffect();
        }

        private void SelectTab(ButtonComponent button)
        {
            currentButton?.HoverDesactivate();
            button?.HoverActivate();
            currentButton = button;
        }
    }
}
