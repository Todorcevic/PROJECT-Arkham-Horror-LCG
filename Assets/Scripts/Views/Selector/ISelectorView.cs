using Arkham.Components;
using UnityEngine;

namespace Arkham.Views
{
    public interface ISelectorView
    {
        string CardInThisSelector { get; }
        bool IsEmpty { get; }
        InteractableComponent Interactable { get; }
        Transform Transform { get; }
        void Init();
        void MoveTo(Transform transform);
        void Arrange(Transform transform);
        void SetSelector(string cardId, Sprite cardImage = null);
        void ActivateGlow(bool activate);
    }
}
