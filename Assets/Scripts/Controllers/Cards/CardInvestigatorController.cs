using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Models;
using Arkham.Investigators;
using Zenject;
using Arkham.Services;
using UnityEngine.EventSystems;
using Arkham.Managers;
using Arkham.Repositories;

namespace Arkham.Views
{
    public class CardInvestigatorController : CardController
    {
        [Inject] InvestigatorSelectorsManager selectorsManager;
        public InvestigatorInfo Investigator { get; set; }
        private List<string> InvestigatorsSelected => selectorsManager.InvestigatorsSelected;

        /*******************************************************************/
        public override void DoubleClick()
        {
            selectorsManager.AddInvestigator(this);
            UpdateVisualState();
        }

        protected override int AmountSelected() => InvestigatorsSelected.FindAll(s => s == Id).Count;
    }
}
