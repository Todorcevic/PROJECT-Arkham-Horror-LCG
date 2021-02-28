using Arkham.Components;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardView
    {
        string Id { get; }
        Transform Transform { get; }
        InteractableComponent Interactable { get; }
        Sprite GetCardImage { get; }
        void Init(string id, Sprite sprite);
        void Activate(bool isEnable);
        void Show(bool isShow);
    }
}
