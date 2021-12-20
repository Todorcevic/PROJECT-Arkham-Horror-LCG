using Arkham.Application;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public static class AutoScroll
    {
        public static void AutoFocus(this ScrollRect scroll, Transform itemTransform, out Vector2 finalItemPosition)
        {
            float originalScrollPosition = scroll.verticalNormalizedPosition;
            float scrollPosition = (scroll.content.rect.height + itemTransform.localPosition.y) / scroll.content.rect.height;
            scroll.verticalNormalizedPosition = scrollPosition;
            finalItemPosition = itemTransform.position;
            scroll.verticalNormalizedPosition = originalScrollPosition;
            scroll.DOVerticalNormalizedPos(scrollPosition, ViewValues.STANDARD_TIME);
        }
    }
}
