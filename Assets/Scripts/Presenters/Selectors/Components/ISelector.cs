using UnityEngine;

namespace Arkham.Presenters
{
    public interface ISelector
    {
        string Id { get; }
        bool IsEmpty { get; }
        void SetSelector(string cardId, Sprite cardImage = null);
        void ActivateGlow(bool activate);
    }
}
