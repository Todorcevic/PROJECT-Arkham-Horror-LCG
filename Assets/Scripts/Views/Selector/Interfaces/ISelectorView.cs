using Arkham.Components;
using UnityEngine;

namespace Arkham.Views
{
    public interface ISelectorView
    {
        string Id { get; }
        bool IsEmpty { get; }
        Transform Transform { get; }
        void SetSelector(string cardId, Sprite cardImage = null);
        void ActivateGlow(bool activate);
    }
}
