using Arkham.Config;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Arkham.Application
{
    public class PlaceHoldersZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, Required] private Image glow;
        [SerializeField, Required] private RectTransform rectTransform;

        public RectTransform RectTransform => rectTransform;
        public bool IsAtive { get; private set; }

        /*******************************************************************/
        private void Start()
        {
            Activate(false);
        }

        public void Activate(bool isActivate)
        {
            glow.CrossFadeAlpha(isActivate ? 1 : 0, ViewValues.STANDARD_TIME, true);
            IsAtive = isActivate;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //glow.color = normal;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //glow.color = big;
        }

        //public void OnDrop(PointerEventData eventData)
        //{
        //    CardView cardView = eventData.pointerDrag.GetComponent<CardView>();
        //    if (cardView is InvestigatorCardView investigatorCardView)
        //    {
        //        investigatorCardView.DropCard();
        //    }
        //}
    }
}
