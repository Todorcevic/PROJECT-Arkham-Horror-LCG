using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using DG.Tweening;
using Arkham.Config;

namespace Arkham.Application
{
    public abstract class CardController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler//, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField, Required] protected CardView cardView;
        [SerializeField, Required, ChildGameObjectsOnly] protected InteractableAudio audioInteractable;

        /*******************************************************************/
        protected abstract void Clicked(PointerEventData eventData);

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => Clicked(eventData);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            cardView.Glow.DOFade(1, ViewValues.STANDARD_TIME);
            audioInteractable.HoverOnSound();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardView.Glow.DOFade(0, ViewValues.STANDARD_TIME);
        }

        protected void CantAdd()
        {
            DOTween.Complete(gameObject.GetInstanceID());
            transform.DOPunchPosition(Vector3.right * 20, ViewValues.FAST_TIME, 40, 5).SetId(gameObject.GetInstanceID());
        }

        //void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        //{
        //    throw new NotImplementedException();
        //}

        //void IDragHandler.OnDrag(PointerEventData eventData)
        //{
        //    throw new NotImplementedException();
        //}

        //void IDropHandler.OnDrop(PointerEventData eventData)
        //{
        //    throw new NotImplementedException();
        //}

        //void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
