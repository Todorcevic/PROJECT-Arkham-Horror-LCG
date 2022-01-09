using DG.Tweening;
using UnityEngine;

namespace Arkham.Application
{
    public class DotweenService
    {
        public Tween SwapImage(Transform imageTransform, TweenCallback callBack)
        {
            return DOTween.Sequence().Append(imageTransform.DORotate(Vector3.up * 90, ViewValues.FAST_TIME))
                   .AppendCallback(callBack)
                   .Append(imageTransform.DORotate(Vector3.zero, ViewValues.FAST_TIME));
        }
    }
}
