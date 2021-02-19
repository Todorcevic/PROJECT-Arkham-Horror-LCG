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
        private readonly ISelectorView selectorView;
        private readonly IInvestigatorsSelectedInteractor selectorIterator;

        /*******************************************************************/
        public SelectorController(ISelectorView selectorView, IInvestigatorsSelectedInteractor selectorIterator)
        {
            this.selectorView = selectorView;
            this.selectorIterator = selectorIterator;
            Init();
        }

        /*******************************************************************/
        private void Init()
        {
            selectorView.Interactable.AddDoubleClickAction(() => Click());
            selectorView.Interactable.AddHoverOnAction(() => selectorView.HoverOnEffect());
            selectorView.Interactable.AddHoverOffAction(() => selectorView.HoverOffEffect());
        }

        private void Click()
        {
            selectorView.Click();
            selectorIterator.RemoveInvestigator(selectorView.InvestigatorInThisSelector);
        }
    }
}
