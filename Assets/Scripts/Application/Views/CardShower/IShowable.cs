using UnityEngine;

namespace Arkham.Application
{
    public interface IShowable
    {
        public Vector2 Position { get; }
        public Sprite FrontImage { get; }
        public Sprite BackImage { get; }
    }
}
