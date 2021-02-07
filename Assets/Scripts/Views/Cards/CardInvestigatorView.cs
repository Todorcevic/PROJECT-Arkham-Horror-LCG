using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Models;
using Arkham.Investigators;
using Arkham.Presenters;
using Zenject;
using Arkham.Services;
using UnityEngine.EventSystems;
using Arkham.Controllers;

namespace Arkham.Views
{
    public class CardInvestigatorView : CardView, IPointerClickHandler, ICardInvestigatorView
    {
        [Inject] private readonly IDoubleClickController<ICardInvestigatorView> controller;
        [Inject] private readonly IDoubleClick doubleClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (doubleClick.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                controller.DoubleClick(this);
        }
    }
}
