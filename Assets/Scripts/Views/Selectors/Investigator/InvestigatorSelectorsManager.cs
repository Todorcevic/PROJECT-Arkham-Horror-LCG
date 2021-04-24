using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.View
{
    public class InvestigatorSelectorsManager : IInvestigatorSelectorsManager
    {
        [Inject(Id = "InvestigatorPlaceHolderZone")] private readonly RectTransform placeHoldersZone;
        [Inject] private readonly List<InvestigatorSelectorView> selectors;

        public InvestigatorSelectorView GetLeadSelector => selectors.Find(i => i.IsLeader);

        /*******************************************************************/
        public InvestigatorSelectorView GetEmptySelector() => selectors.Find(selector => selector.Id == null);

        public InvestigatorSelectorView GetSelectorById(string cardId) =>
            selectors.Find(selector => selector.Id == cardId);

        public void EmptyAllSelectors() => selectors.ForEach(s => s.EmptySelector());

        public void ArrangeAllSelectors() => selectors.ForEach(s => s.ArrangeAnimation());

        public void RebuildPlaceHolders() => LayoutRebuilder.ForceRebuildLayoutImmediate(placeHoldersZone);
    }
}
