using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class PlaceHoldersZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, Range(0, 1)] private float timeAnimation;
        [SerializeField] private Image glow;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Color normal;
        [SerializeField] private Color big;

        public RectTransform RectTransform => rectTransform;

        /*******************************************************************/
        private void Start()
        {
            glow.CrossFadeAlpha(0, 0, true);
        }

        public void Activate(bool isActivate) => glow.CrossFadeAlpha(isActivate ? 1 : 0, timeAnimation, true);

        public void OnPointerExit(PointerEventData eventData)
        {
            glow.color = normal;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            glow.color = big;
        }
    }
}
