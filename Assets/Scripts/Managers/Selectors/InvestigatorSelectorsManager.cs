using Arkham.Presenters;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : MonoBehaviour, IInvestigatorSelectorsManager
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, SceneObjectsOnly] private List<InvestigatorSelectorView> selectors;
        public List<IInvestigatorSelectorable> Selectors =>
            selectors.OfType<IInvestigatorSelectorable>().ToList();
        public IInvestigatorSelectorable GetLeadSelector => Selectors.Find(i => i.IsLeader);

        /*******************************************************************/
        public IInvestigatorSelectorable GetEmptySelector() =>
            Selectors.Find(selector => selector.Id == null);

        public IInvestigatorSelectorable GetSelectorById(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId);

        public void SetLeadAndArrangeSelectors(string leadInvestigatorId)
        {
            SetLeadSelector(leadInvestigatorId);
            ArrangeSelectors();
        }

        private void SetLeadSelector(string leadInvestigatorId)
        {
            if (leadInvestigatorId == GetLeadSelector.Id || leadInvestigatorId == null) return;
            GetLeadSelector.ActivateLeaderIcon(false);
            GetSelectorById(leadInvestigatorId).ActivateLeaderIcon(true);
        }

        private void ArrangeSelectors()
        {
            foreach (IInvestigatorSelectorable selector in Selectors)
                selector.Arrange(selector.IsEmpty ? selector.Transform : placeHolder);
        }
    }
}
