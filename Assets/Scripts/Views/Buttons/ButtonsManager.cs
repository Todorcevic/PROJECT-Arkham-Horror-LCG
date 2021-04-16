﻿using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public class ButtonsManager : MonoBehaviour
    {
        private ButtonView currentButton;
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private List<ButtonView> buttons;

        private ButtonView FirstButton => buttons[0];

        /*******************************************************************/
        private void Awake()
        {
            foreach (ButtonView button in buttons)
                ((IClickable)button).AddAction(() => SelectButton(button));
        }

        private void Start() => SelectButton(FirstButton);

        /*******************************************************************/
        public void SelectButton(ButtonView button)
        {
            currentButton?.Lock(false);
            button.Lock(true);
            currentButton = button;
        }
    }
}