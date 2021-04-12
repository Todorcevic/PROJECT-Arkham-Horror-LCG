using UnityEngine;

namespace Arkham.Views
{
    public interface ISelectorView
    {
        string Id { get; }
        bool IsEmpty { get; }
        Transform PlaceHolder { get; }
        void SetSelector(string cardId, Sprite cardImage = null);
        void Glow(bool isOn);
        void Arrange();
        void SetTransform(Transform transform = null);
        void MoveImageTo(Transform transform);
        void SwapPlaceHolder(Transform selectorDragging);
    }
}
