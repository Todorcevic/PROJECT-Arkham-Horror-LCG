using Arkham.Components;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public class SelectorView : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableComponent interactable;
        [SerializeField, Required, ChildGameObjectsOnly] private ImageStateComponent imageState;
        [SerializeField, Required, ChildGameObjectsOnly] private GlowActivator glowActivator;

        public string CardInThisSelector { get; private set; }
        public bool IsEmpty => CardInThisSelector == null;
        public InteractableComponent Interactable => interactable;
        public Transform Transform => transform;

        /*******************************************************************/
        public void Init() => interactable.Init();

        public void SetSelector(string cardId, Sprite cardImage = null)
        {
            CardInThisSelector = cardId;
            imageState.Activate(cardId != null);
            imageState.ChangeImage(cardImage);
        }

        public void ActivateGlow(bool activate) => glowActivator.ActivateGlow(activate);

    }
}
