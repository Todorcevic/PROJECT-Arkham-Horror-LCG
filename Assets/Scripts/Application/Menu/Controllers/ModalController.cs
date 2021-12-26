using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public class ModalController : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, ChildGameObjectsOnly] private PanelView modal;
        [SerializeField, ChildGameObjectsOnly] private List<ButtonView> buttons;

        /*******************************************************************/
        private void Awake() => buttons.ForEach(button => button.ClickAction += CloseThisModal);

        private void CloseThisModal() => modal.Activate(false);
    }
}
