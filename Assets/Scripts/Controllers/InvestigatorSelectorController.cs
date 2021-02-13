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

        /*******************************************************************/
        public void Click(IInvestigatorSelectorView selectorView)
        {
            selectorManager.SelectSelector(selectorView);
            selectorView.ClickEffect();
        }

        public void DoubleClick(IInvestigatorSelectorView selectorView) =>
            selectorManager.RemoveSelector(selectorView);

        public void HoverOn(IInvestigatorSelectorView selectorView) => selectorView.HoverOnEffect();

        public void HoverOff(IInvestigatorSelectorView selectorView) => selectorView.HoverOffEffect();
    }
}
