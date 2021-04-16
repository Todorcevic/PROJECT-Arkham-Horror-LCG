﻿using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public class ModalController : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, ChildGameObjectsOnly] private PanelView modal;
        [SerializeField, ChildGameObjectsOnly] private List<ButtonView> buttons;

        /*******************************************************************/
        private void Awake()
        {
            foreach (IClickable button in buttons)
                button.AddAction(CloseThisModal);
        }

        private void CloseThisModal() => modal.Activate(false);
    }
}