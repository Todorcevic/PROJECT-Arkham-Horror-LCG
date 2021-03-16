using UnityEngine;

namespace Arkham.Presenters
{
    public interface ICardVisualizable
    {
        string Id { get; }
        Vector3 Position { get; }
        Sprite GetCardImage { get; }
        void Activate(bool isEnable);
    }
}
