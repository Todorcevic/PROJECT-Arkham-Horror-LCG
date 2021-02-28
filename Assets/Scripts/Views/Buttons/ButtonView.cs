using Arkham.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        public InteractableComponent Interactable => interactable;

        /*******************************************************************/
        private void Start()
        {
            interactable.Init();
        }
    }
}