using Arkham.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class ButtonView : MonoBehaviour, IInitializable
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;

        public void Initialize()
        {
            interactable.Clicked += interactable.ClickEffect;
            interactable.HoverOn += interactable.HoverOnEffect;
            interactable.HoverOff += interactable.HoverOffEffect;
        }
    }
}
