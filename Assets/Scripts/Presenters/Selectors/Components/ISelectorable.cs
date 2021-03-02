using UnityEngine;

namespace Arkham.Presenters
{
    public interface ISelectorable
    {
        string Id { get; }
        bool IsEmpty { get; }
        Transform Transform { get; }
        void SetSelector(string cardId, Sprite cardImage = null);
        void ActivateGlow(bool activate);
    }
}
