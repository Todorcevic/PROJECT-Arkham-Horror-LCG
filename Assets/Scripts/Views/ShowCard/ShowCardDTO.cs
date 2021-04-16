using UnityEngine;

namespace Arkham.Views
{
    public class ShowCardDTO
    {
        public string CardId { get; }
        public Color ImageColor { get; }
        public Vector2 Position { get; }

        public ShowCardDTO(string id, Color color, Vector2 position)
        {
            CardId = id;
            ImageColor = color;
            Position = position;
        }
    }
}
