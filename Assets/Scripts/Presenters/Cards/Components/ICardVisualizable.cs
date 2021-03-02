using Arkham.Controllers;
using UnityEngine;

namespace Arkham.Presenters
{
    public interface ICardVisualizable
    {
        string Id { get; }
        Transform Transform { get; }
        InteractableComponent Interactable { get; }
        Sprite GetCardImage { get; }
        void Activate(bool isEnable);
        void Show(bool isShow);
    }
}
