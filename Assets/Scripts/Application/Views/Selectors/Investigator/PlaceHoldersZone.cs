using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class PlaceHoldersZone : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float timeAnimation;
        [SerializeField] private Image glow;
        [SerializeField] private RectTransform rectTransform;

        public RectTransform RectTransform => rectTransform;

        /*******************************************************************/
        private void Start()
        {
            glow.CrossFadeAlpha(0, 0, true);
        }

        public void Activate(bool isActivate) => glow.CrossFadeAlpha(isActivate ? 1 : 0, timeAnimation, true);
    }
}
