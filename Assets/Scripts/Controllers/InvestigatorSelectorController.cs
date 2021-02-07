using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Views;
using UnityEngine.EventSystems;
using Arkham.Models;
using Arkham.Repositories;
using Arkham.UseCases;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IFullController<IInvestigatorSelectorView>
    {
        private readonly Repository allData;
        private readonly IInvestigatorSelector selectorLogic;

        /*******************************************************************/
        public InvestigatorSelectorController(Repository allData, IInvestigatorSelector selectorLogic)
        {
            this.allData = allData;
            this.selectorLogic = selectorLogic;
        }

        /*******************************************************************/
        public void Click(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {
            allData.InvestigatorSelected = allData.InvestigatorsSelectedList[investigatorSelectorView.Id];
        }

        public void DoubleClick(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {
            selectorLogic.RemoveInvestigator(investigatorSelectorView.Id);
        }

        public void HoverOn(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {
            if (HasInvestigator(investigatorSelectorView))
                investigatorSelectorView.HoverOnEffect();
        }

        public void HoverOff(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {
            if (HasInvestigator(investigatorSelectorView))
                investigatorSelectorView.HoverOffEffect();
        }

        private bool HasInvestigator(IInvestigatorSelectorView investigatorSelectorView) =>
            allData.InvestigatorsSelectedList[investigatorSelectorView.Id].Length > 0;
    }
}
