using Arkham.Presenters;
using UnityEngine;

namespace Arkham.Views
{
    public interface IShowCard
    {
        void ShowingPreviewCard(ICardVisualizable cardView);
        void HidePreviewCard();
        void MoveAnimation();
    }
}
