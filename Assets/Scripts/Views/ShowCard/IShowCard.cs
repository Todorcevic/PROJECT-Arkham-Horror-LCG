using Arkham.Presenters;
using UnityEngine;

namespace Arkham.Views
{
    public interface IShowCard
    {
        Transform Transform { get; }
        void ShowInLeftSide(ShowCardDTO showableCard);
        void ShowInRightSide(ShowCardDTO showableCard);
        void HidePreviewCard();
        void AddMoveAnimation();
        void RemoveMoveAnimation(bool withReshow);
    }
}
