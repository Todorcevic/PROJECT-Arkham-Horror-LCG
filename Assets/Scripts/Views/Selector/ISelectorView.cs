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
        void MoveImageTo(Vector3 position);
        void SwapPlaceHolder(Transform selectorDragging);
    }
}
