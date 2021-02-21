using Arkham.Interactors;
using Arkham.UseCases;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Controllers
{
    public class SelectorController : ISelectorController
    {
        [Inject] private readonly IInvestigatorsSelectorInteractor investigatorSelector;

        /*******************************************************************/
        public void Init(ISelectorView selectorView)
        {
            selectorView.Interactable.AddClickAction(() => Click(selectorView));
            selectorView.Interactable.AddDoubleClickAction(() => DoubleClick(selectorView));
            selectorView.Interactable.AddHoverOnAction(() => selectorView.HoverOnEffect());
            selectorView.Interactable.AddHoverOffAction(() => selectorView.HoverOffEffect());
        }

        private void Click(ISelectorView selectorView)
        {
            selectorView.Click();
            investigatorSelector.SelectInvestigator(selectorView.InvestigatorInThisSelector);
        }

        private void DoubleClick(ISelectorView selectorView) =>
            investigatorSelector.RemoveInvestigator(selectorView.InvestigatorInThisSelector);
    }
}
