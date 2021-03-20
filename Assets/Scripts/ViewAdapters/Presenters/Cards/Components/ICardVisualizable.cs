using UnityEngine;

namespace Arkham.Presenters
{
    public interface ICardVisualizable
    {
        string Id { get; }
        bool IsInactive { get; }
        Transform Transform { get; }
        Sprite GetCardImage { get; }
        void Activate(bool isEnable);
        void Show(bool isEnable);
    }
}
