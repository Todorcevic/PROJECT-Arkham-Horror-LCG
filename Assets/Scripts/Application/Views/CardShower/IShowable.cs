using UnityEngine;

namespace Arkham.Application
{
    public interface IShowable
    {
        public Vector2 StartPosition { get; }
        public Vector2 ShowPosition { get; }
        public Sprite FrontImage { get; }
        public Sprite BackImage { get; }
    }
}
