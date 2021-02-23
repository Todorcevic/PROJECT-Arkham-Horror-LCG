using Arkham.Controllers;
using Arkham.Views;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : MonoBehaviour, IInvestigatorSelectorsManager
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, SceneObjectsOnly] private List<InvestigatorSelectorView> selectors;
        public List<IInvestigatorSelectorView> Selectors => selectors.OfType<IInvestigatorSelectorView>().ToList();

        /*******************************************************************/
        public IInvestigatorSelectorView GetSelectorByInvestigator(string investigatorId) =>
            selectors.Find(i => i.InvestigatorInThisSelector == investigatorId);

        public IInvestigatorSelectorView GetSelectorVoid() =>
            selectors.Find(i => i.InvestigatorInThisSelector == null);

        public void ArrangeSelectors()
        {
            foreach (IInvestigatorSelectorView selector in selectors)
                selector.Arrange(selector.IsEmpty ? selector.Transform : placeHolder);
        }
    }
}
