using System;
using UnityEngine;

namespace Arkham.Application.MainMenu
{
    public interface IShowable
    {
        public bool MustReshow { get; }
        public bool IsInactive { get; }
        public Vector2 StartPosition { get; }
        public Vector2 ShowPosition { get; }
        public Sprite FrontImage { get; }
        public Sprite BackImage { get; }
    }
}
