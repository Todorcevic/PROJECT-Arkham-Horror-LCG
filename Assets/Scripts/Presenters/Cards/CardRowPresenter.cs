using Arkham.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Presenters
{
    public class CardRowPresenter : IFullInteractablePresenter<CardRowView>
    {
        void IPresenter<CardRowView>.CreateReactiveViewModel(CardRowView objectView)
        {

        }
        void IClickPresenter<CardRowView>.Click(CardRowView objectView, PointerEventData eventData)
        {

        }

        void IFullInteractablePresenter<CardRowView>.HoverOff(CardRowView objectView, PointerEventData eventData)
        {

        }

        void IFullInteractablePresenter<CardRowView>.HoverOn(CardRowView objectView, PointerEventData eventData)
        {

        }
    }
}
