using Arkham.Views;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : MonoBehaviour, IInvestigatorSelectorsManager
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, SceneObjectsOnly] private List<InvestigatorSelectorView> selectors;
        public List<IInvestigatorSelectorView> Selectors =>
            selectors.OfType<IInvestigatorSelectorView>().ToList();
        public IInvestigatorSelectorView GetLeadSelector => Selectors.Find(i => i.IsLead);

        /*******************************************************************/
        public IInvestigatorSelectorView GetEmptySelector() =>
            Selectors.Find(selector => selector.Id == null);

        public List<IInvestigatorSelectorView> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.Id != null);

        public IInvestigatorSelectorView GetSelectorById(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId);

        public void ArrangeSelectors()
        {
            foreach (IInvestigatorSelectorView selector in Selectors)
                selector.Arrange(selector.IsEmpty ? selector.Transform : placeHolder);
        }
    }
}
