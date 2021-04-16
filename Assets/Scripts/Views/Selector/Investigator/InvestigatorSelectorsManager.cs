using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class InvestigatorSelectorsManager : MonoBehaviour, IInvestigatorSelectorsManager
    {
        [Title("RESOURCES")]
        [SerializeField, Required, SceneObjectsOnly] private RectTransform placeHoldersZone;
        [SerializeField, Required, SceneObjectsOnly] private List<InvestigatorSelectorView> selectors;

        public Transform PlaceHoldersZone => placeHoldersZone;
        public List<InvestigatorSelectorView> Selectors => selectors;
        public InvestigatorSelectorView GetLeadSelector => selectors.Find(i => i.IsLeader);

        /*******************************************************************/
        public InvestigatorSelectorView GetEmptySelector() => Selectors.Find(selector => selector.Id == null);

        public InvestigatorSelectorView GetSelectorById(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId);

        public void RebuildPlaceHolders() => LayoutRebuilder.ForceRebuildLayoutImmediate(placeHoldersZone);
    }
}
