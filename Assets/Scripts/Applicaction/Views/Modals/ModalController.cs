using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Application
{
    public class ModalController : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, ChildGameObjectsOnly] private PanelView modal;
        [SerializeField, ChildGameObjectsOnly] private List<ButtonView> buttons;

        /*******************************************************************/
        private void Awake()
        {
            foreach (ButtonView button in buttons)
                button.AddClickAction(CloseThisModal);
        }

        private void CloseThisModal() => modal.Activate(false);
    }
}
