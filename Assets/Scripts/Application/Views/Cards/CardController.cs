using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Sirenix.OdinInspector;
using DG.Tweening;
using Arkham.Config;

namespace Arkham.Application
{
    public abstract class CardController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler//, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [Inject] private readonly ShowCard showCard;
        [SerializeField, Required] protected CardView cardView;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;

        /*******************************************************************/
        protected abstract void Clicked();

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            audioInteractable.ClickSound();
            if (cardView.IsInactive) CantAdd();
            else Clicked();

            void CantAdd()
            {
                DOTween.Complete(gameObject.GetInstanceID());
                transform.DOPunchPosition(Vector3.right * 20, ViewValues.FAST_TIME, 40, 5).SetId(gameObject.GetInstanceID());
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            cardView.Glow.DOFade(1, ViewValues.STANDARD_TIME);
            audioInteractable.HoverOnSound();
            showCard.Set(cardView);
            showCard.ShowAnimation();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardView.Glow.DOFade(0, ViewValues.STANDARD_TIME);
            showCard.Hide();
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
