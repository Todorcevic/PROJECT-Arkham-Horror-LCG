using DG.Tweening;
using System;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ScrollCampaignButtonIconEventHandler : IInitializable, IDisposable
    {
        private const float SCROLL_AMOUNT = 0.35f;
        [Inject(Id = "LeftScrollButton")] private readonly ButtonIconView leftScrollButton;
        [Inject(Id = "RightScrollButton")] private readonly ButtonIconView rightScrollButton;
        [Inject(Id = "ScrollRectCampaign")] private readonly ScrollRect scrollRectCampaign;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            leftScrollButton.ClickAction += ClickedLeft;
            rightScrollButton.ClickAction += ClickedRight;
        }
        void IDisposable.Dispose()
        {
            leftScrollButton.ClickAction -= ClickedLeft;
            rightScrollButton.ClickAction -= ClickedRight;
        }

        private void ClickedLeft() => scrollRectCampaign.DOHorizontalNormalizedPos(scrollRectCampaign.horizontalNormalizedPosition - SCROLL_AMOUNT, ViewValues.STANDARD_TIME);
        private void ClickedRight() => scrollRectCampaign.DOHorizontalNormalizedPos(scrollRectCampaign.horizontalNormalizedPosition + SCROLL_AMOUNT, ViewValues.STANDARD_TIME);
    }
}
