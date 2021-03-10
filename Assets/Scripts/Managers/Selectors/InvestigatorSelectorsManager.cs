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
        [SerializeField, Required, SceneObjectsOnly] private Transform selectorZone;
        [SerializeField, Required, SceneObjectsOnly] private List<InvestigatorSelectorView> selectors;
        public List<IInvestigatorSelector> Selectors =>
            selectors.OfType<IInvestigatorSelector>().ToList();

        public Transform SelectorZone => selectorZone;
        /*******************************************************************/
        public IInvestigatorSelector GetEmptySelector() => Selectors.Find(selector => selector.Id == null);

        public IInvestigatorSelector GetSelectorById(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId);

        public void ArrangeSelectors()
        {
            foreach (InvestigatorSelectorView selector in selectors)
            {
                selector.SelectorMovement.SetParent(selector.IsEmpty ? transform : selectorZone);
                selector.SelectorMovement.Arrange();
            }
        }
    }
}
