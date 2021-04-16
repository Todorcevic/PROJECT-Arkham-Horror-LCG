using Arkham.EventData;
using Arkham.Presenters;
using Arkham.Views;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Controllers
{
    public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, Required, ChildGameObjectsOnly] protected CardView cardView;
        [Inject] protected readonly IShowCard showCard;

        /*******************************************************************/
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            cardView.HoverOnEffect();
            showCard.ShowInLeftSide(new ShowCardDTO(cardView.Id, cardView.IsInactive ? Color.gray : Color.white, cardView.Transform.position));
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            cardView.HoverOffEffect();
            showCard.HidePreviewCard();
        }
    }
}
