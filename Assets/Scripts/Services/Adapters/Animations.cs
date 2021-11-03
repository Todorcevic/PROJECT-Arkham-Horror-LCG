using UnityEngine;
using DG.Tweening;
using Assets.Scripts.Config;

namespace Arkham.Services
{
    public class Animations
    {
        public void GlowOn(CanvasGroup canvasGlow) => canvasGlow.DOFade(1, ViewValues.STANDARD_TIME);
        public void GlowOff(CanvasGroup canvasGlow) => canvasGlow.DOFade(0, ViewValues.STANDARD_TIME);

        public void CantAdd(Transform transform)
        {
            DOTween.Complete("CantAdd");
            transform.DOPunchPosition(Vector3.right * 10, ViewValues.FAST_TIME, 20, 5).SetId("CantAdd");
        }
    }
}
