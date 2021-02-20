using Arkham.Interactors;
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
        [Inject] private readonly IInvestigatorsSelectedInteractor selectorIterator;

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
            selectorIterator.SelectInvestigator(selectorView.InvestigatorInThisSelector);
        }

        private void DoubleClick(ISelectorView selectorView) =>
            selectorIterator.RemoveInvestigator(selectorView.InvestigatorInThisSelector);
    }
}
