using System.Collections.Generic;
using UnityEngine.UI;
using Zenject;
using UnityEngine;

namespace Arkham.Application
{
    public class InvestigatorSelectorsManager
    {
        private string currentInvestigator;
        [Inject(Id = "PlaceHoldersZone")] private readonly RectTransform placeHoldersZone;
        [Inject] private readonly List<InvestigatorSelectorView> selectors;

        public string InvestigatorSelected => currentInvestigator;
        public InvestigatorSelectorView GetCurrentLeadSelector => selectors.Find(invSelectorView => invSelectorView.IsLeader);
        public InvestigatorSelectorView GetRealLeadSelector => selectors[0];

        /*******************************************************************/
        public InvestigatorSelectorView GetEmptySelector() => selectors.Find(selector => selector.Id == null);

        public InvestigatorSelectorView GetSelectorById(string cardId) =>
            selectors.Find(selector => selector.Id == cardId);

        public void ResetSelectors()
        {
            selectors.ForEach(selector => ResetSelector(selector));
            RebuildPlaceHolders();
            selectors.ForEach(selector => selector.PosicionateCardOff());

            void ResetSelector(InvestigatorSelectorView selector)
            {
                selector.EmptySelector();
                selector.ActivateSensor(false);
                selector.Glow(false);
            }
        }

        public void ArrangeAllSelectors()
        {
            RebuildPlaceHolders();
            selectors.ForEach(s => s.ArrangeAnimation());
        }

        public void RebuildPlaceHolders() => LayoutRebuilder.ForceRebuildLayoutImmediate(placeHoldersZone);

        public void SelectInvestigator(string activeInvestigatorId)
        {
            RemoveGlowInOldInvestigator();
            currentInvestigator = activeInvestigatorId;
            ActiveGlowInNewInvestigator();

            void RemoveGlowInOldInvestigator() => GetSelectorById(currentInvestigator)?.Glow(false);

            void ActiveGlowInNewInvestigator() => GetSelectorById(currentInvestigator)?.Glow(true);
        }
    }
}
