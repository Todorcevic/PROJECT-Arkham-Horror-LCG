using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Sirenix.OdinInspector;
using Arkham.Services;

namespace Arkham.Application
{
    public abstract class CardController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler//, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [Inject] private readonly Animations animations;
        [Inject] private readonly ShowCard showCard;
        [SerializeField, Required] protected CardView cardView;
        [SerializeField, Required, ChildGameObjectsOnly] private InteractableAudio audioInteractable;

        /*******************************************************************/
        protected abstract void Clicked();

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            audioInteractable.ClickSound();
            if (cardView.IsInactive) animations.CantAdd(cardView.transform);
            else Clicked();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            animations.GlowOn(cardView.Glow);
            audioInteractable.HoverOnSound();
            showCard.Set(cardView);
            showCard.ShowAnimation();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            animations.GlowOff(cardView.Glow);
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
