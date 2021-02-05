using Arkham.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Presenters
{
    public class CardDeckPresenter : IFullInteractablePresenter<CardDeckView>
    {
        void IClickPresenter<CardDeckView>.Click(CardDeckView objectView, PointerEventData eventData)
        {

        }

        void IFullInteractablePresenter<CardDeckView>.HoverOff(CardDeckView objectView, PointerEventData eventData)
        {

        }

        void IFullInteractablePresenter<CardDeckView>.HoverOn(CardDeckView objectView, PointerEventData eventData)
        {

        }

        void IPresenter<CardDeckView>.CreateReactiveViewModel(CardDeckView objectView)
        {

        }
    }
}
