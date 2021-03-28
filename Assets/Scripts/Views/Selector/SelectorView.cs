using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Arkham.Views
{
    public class SelectorView : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private Activator activator;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private ImageConfigurator imageConfigurator;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private SelectorMovement selectorMovement;
        [SerializeField, Required, ChildGameObjectsOnly, TitleGroup("RESOURCES")] private GlowActivator glowActivator;

        public string Id { get; protected set; }
        public bool IsEmpty => Id == null;
        public Transform PlaceHolder => selectorMovement.PlaceHolder;

        /*******************************************************************/
        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            Id = cardId;
            imageConfigurator.ChangeImage(cardImage);
            activator.Activate(cardImage != null);
        }

        public void Glow(bool isOn) => glowActivator.ActivateGlow(isOn);

        public void Arrange() => selectorMovement.Arrange();

        public void SetTransform(Transform transform = null) => selectorMovement.SetTransform(transform);

        public void MoveImageTo(Vector3 position) => selectorMovement.MoveImageTo(position);

        public void SwapPlaceHolder(Transform selectorDragging) => selectorMovement.SwapPlaceHolder(selectorDragging);
    }
}
