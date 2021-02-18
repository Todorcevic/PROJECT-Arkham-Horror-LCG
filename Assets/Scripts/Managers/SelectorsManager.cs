using Arkham.Controllers;
using Arkham.Iterators;
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
    public class SelectorsManager : MonoBehaviour, ISelectorsManager
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, ChildGameObjectsOnly] private List<SelectorView> selectors;
        public List<SelectorView> Selectors => selectors;

        /*******************************************************************/
        public ISelectorView GetSelectorByInvestigator(string investigatorId) =>
            selectors.Find(i => i.InvestigatorInThisSelector == investigatorId);

        public ISelectorView GetSelectorVoid() =>
            selectors.Find(i => i.InvestigatorInThisSelector == null);

        public void ArrangeSelectors()
        {
            foreach (ISelectorView selector in selectors)
                selector.Arrange(selector.IsEmpty ? selector.Transform : placeHolder);
        }
    }
}
