using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Arkham.Views
{
    public class GlowActivator : MonoBehaviour
    {
        [Title("RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private Image glow;
        [SerializeField, Required, ChildGameObjectsOnly] private CanvasGroup canvasGlow;
        [Title("SETTINGS")]
        [SerializeField, Range(0f, 1f)] private float timeHoverAnimation;

        /*******************************************************************/
        public void ActivateGlow(bool activate) => canvasGlow.DOFade(activate ? 1 : 0, timeHoverAnimation);
    }
}
