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
        public Transform PlaceHolder => placeHolder;
        public List<IInvestigatorSelectorView> Selectors =>
            selectors.OfType<IInvestigatorSelectorView>().ToList();

        /*******************************************************************/
        public IInvestigatorSelectorView GetEmptySelector() =>
            Selectors.Find(selector => selector.CardInThisSelector == null);

        public List<IInvestigatorSelectorView> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.CardInThisSelector != null);

        public IInvestigatorSelectorView GetSelectorById(string cardId) =>
            Selectors.Find(selector => selector.CardInThisSelector == cardId);
    }
}
