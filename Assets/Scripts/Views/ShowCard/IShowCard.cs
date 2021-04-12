using Arkham.Presenters;
using UnityEngine;

namespace Arkham.Views
{
    public interface IShowCard
    {
        Transform Transform { get; }
        void ShowInLeftSide(IShowable showableCard);
        void ShowInRightSide(IShowable showableCard);
        void HidePreviewCard();
        void AddMoveAnimation();
        void RemoveMoveAnimation(bool withReshow);
    }
}
