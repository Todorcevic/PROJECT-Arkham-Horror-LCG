using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Models;
using Arkham.Investigators;
using Zenject;
using Arkham.Services;
using UnityEngine.EventSystems;
using Arkham.Controllers;

namespace Arkham.Views
{
    public class CardInvestigatorView : CardView, IPointerClickHandler
    {
        [Inject] private readonly IDoubleClickDetector doubleClick;
        [Inject] private readonly ICardInvestigatorController investigatorController;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (doubleClick.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                investigatorController.DoubleClick(this);
        }
    }
}
