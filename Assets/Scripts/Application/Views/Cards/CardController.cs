using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using DG.Tweening;

namespace Arkham.Application
{
    public abstract class CardController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler//, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [Inject] private readonly ShowCard showCard;
        [SerializeField] protected CardView cardView;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            cardView.ClickEffect();
            if (cardView.IsInactive) cardView.CantAddAnimation();
            else Clicked();
        }

        protected abstract void Clicked();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            cardView.HoverOnEffect();
            showCard.Set(new CardShowDTO() { Position = transform.position, Front = cardView.GetCardImage, Back = cardView.GetBackImage });
            showCard.ShowAnimation();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardView.HoverOffEffect();
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
