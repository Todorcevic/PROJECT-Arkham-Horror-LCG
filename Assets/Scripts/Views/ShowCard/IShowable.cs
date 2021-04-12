using UnityEngine;

namespace Arkham.Views
{
    public interface IShowable
    {
        string CardId { get; }
        Color ImageColor { get; }
        Vector2 Position { get; }
    }
}
