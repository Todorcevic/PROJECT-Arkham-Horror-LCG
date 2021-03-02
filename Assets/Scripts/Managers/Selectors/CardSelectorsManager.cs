using Arkham.Presenters;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class CardSelectorsManager : MonoBehaviour, ICardSelectorsManager
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform zone;
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, SceneObjectsOnly] private List<CardSelectorView> selectors;
        public Transform Zone => zone;
        public List<ICardSelectorable> Selectors =>
            selectors.OfType<ICardSelectorable>().ToList();

        /*******************************************************************/
        public List<ICardSelectorable> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.Id != null);

        public ICardSelectorable GetSelectorByCardIdOrEmpty(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId) ?? GetEmptySelector();

        private ICardSelectorable GetEmptySelector() =>
            Selectors.Find(selector => selector.Id == null);

        public void CleanAllSelectors()
        {
            foreach (ICardSelectorable selector in GetAllFilledSelectors())
                DesactivateSelector(selector);
        }

        public void DesactivateSelector(ICardSelectorable selector)
        {
            selector.SetSelector(null);
            selector.Transform.SetParent(placeHolder);
        }
    }
}
