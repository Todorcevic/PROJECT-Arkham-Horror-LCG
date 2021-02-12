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
    public class CardInvestigatorComponent : CardComponent, IPointerClickHandler, IInvestigatorComponent
    {
        public Investigator Investigator { get; set; }

        /*******************************************************************/
        [Inject]
        private void Init(ICardController controller)
        {
            Controller = controller;
            Controller.Init(this);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (doubleClick.CheckDoubleClick(eventData.clickTime, eventData.pointerPress))
                Controller.DoubleClick();
        }
    }
}
