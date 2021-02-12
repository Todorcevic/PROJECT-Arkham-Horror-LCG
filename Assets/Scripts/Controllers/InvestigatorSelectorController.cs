using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.Views;
using UnityEngine.EventSystems;
using Zenject;
using Arkham.Repositories;
using Arkham.UI;
using Arkham.Managers;

namespace Arkham.Controllers
{
    public class InvestigatorSelectorController : IInvestigatorSelectorController
    {
        [Inject] private readonly IInvestigatorSelectorsManager selectorManager;
        private IInvestigatorSelectorView selectorView;

        /*******************************************************************/
        public void Init(IInvestigatorSelectorView selectorView) => this.selectorView = selectorView;

        public void Click()
        {
            selectorManager.SelectSelector(selectorView);
            selectorView.ClickEffect();
        }

        public void DoubleClick() => selectorManager.RemoveSelector(selectorView);

        public void HoverOn() => selectorView.HoverOnEffect();

        public void HoverOff() => selectorView.HoverOffEffect();
    }
}
