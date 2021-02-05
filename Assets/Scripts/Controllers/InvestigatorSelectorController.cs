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
        DeselectInvestigator deselect;

        public InvestigatorSelectorController(GameData gameData, Repository allData, DeselectInvestigator deselect)
        {
            this.allData = allData;
            this.deselect = deselect;
        }

        public void Click(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {
            allData.InvestigatorSelected = allData.InvestigatorsSelectedList[investigatorSelectorView.Id];
        }

        public void DoubleClick(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {
            deselect.Deselect(investigatorSelectorView.Id);
            //allData.InvestigatorsSelectedList[investigatorSelectorView.Id] = string.Empty;
        }

        public void HoverOff(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {

        }

        public void HoverOn(IInvestigatorSelectorView investigatorSelectorView, PointerEventData eventData)
        {

        }
    }
}
