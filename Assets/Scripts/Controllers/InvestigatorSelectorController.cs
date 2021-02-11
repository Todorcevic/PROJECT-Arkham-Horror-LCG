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
        [Inject] IInvestigatorSelectorsManager selectorManager;
        private InvestigatorSelectorView currentSelectorSelected;

        /*******************************************************************/

        public void Click(InvestigatorSelectorView selectorView)
        {
            currentSelectorSelected?.ActivateGlow(false);
            selectorView.ActivateGlow(true);
            selectorView.ClickEffect();
            currentSelectorSelected = selectorView;
        }

        public void DoubleClick(InvestigatorSelectorView selectorView) =>
            selectorManager.RemoveSelector(selectorView);

        public void HoverOn(InvestigatorSelectorView selectorView) =>
            selectorView.HoverOnEffect();

        public void HoverOff(InvestigatorSelectorView selectorView) =>
            selectorView.HoverOffEffect();
    }
}
