using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorsManager
    {
        [Inject(Id = "InvestigatorPlaceHolderZone")] private readonly RectTransform placeHoldersZone;
        [Inject] private readonly List<InvestigatorSelectorView> selectors;

        public InvestigatorSelectorView GetLeadSelector => selectors.Find(i => i.IsLeader);
        public InvestigatorSelectorView GetRealLeadSelector => selectors[0];

        /*******************************************************************/
        public InvestigatorSelectorView GetEmptySelector() => selectors.Find(selector => selector.Id == null);

        public InvestigatorSelectorView GetSelectorById(string cardId) =>
            selectors.Find(selector => selector.Id == cardId);

        public void ResetSelectors()
        {
            selectors.ForEach(selector => selector.ResetSelector());
            RebuildPlaceHolders();
            selectors.ForEach(selector => selector.PosicionateCardOff());
        }

        public void ArrangeAllSelectors() => selectors.ForEach(s => s.ArrangeAnimation());

        public void RebuildPlaceHolders() => LayoutRebuilder.ForceRebuildLayoutImmediate(placeHoldersZone);
    }
}
