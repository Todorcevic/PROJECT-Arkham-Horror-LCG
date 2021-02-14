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
    public class CardInvestigatorView : CardView, IPointerClickHandler, IInvestigatorView
    {
        public InvestigatorInfo Investigator { get; set; }

        /*******************************************************************/
        [Inject]
        private void Init(ICardInvestigatorController controller)
        {
            base.controller = controller;
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (doubleClick.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                controller.DoubleClick(this);
        }
    }
}
