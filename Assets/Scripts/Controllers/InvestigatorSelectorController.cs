using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Views;
using UnityEngine.EventSystems;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IFullController<IInvestigatorSelectorView>
    {
        void IClickController<IInvestigatorSelectorView>.Click(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {

        }

        void IHoverController<IInvestigatorSelectorView>.HoverOff(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {

        }

        void IHoverController<IInvestigatorSelectorView>.HoverOn(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {

        }
    }
}
