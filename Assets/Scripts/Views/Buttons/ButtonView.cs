using Arkham.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
    }
}
