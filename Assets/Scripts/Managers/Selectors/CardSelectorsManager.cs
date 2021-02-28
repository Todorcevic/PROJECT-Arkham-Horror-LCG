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
        public List<ICardSelectorView> Selectors =>
            selectors.OfType<ICardSelectorView>().ToList();

        /*******************************************************************/
        public List<ICardSelectorView> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.Id != null);

        public ICardSelectorView GetSelectorByCardIdOrEmpty(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId) ?? GetEmptySelector();

        private ICardSelectorView GetEmptySelector() =>
            Selectors.Find(selector => selector.Id == null);

        public void CleanAllSelectors()
        {
            foreach (ICardSelectorView selector in GetAllFilledSelectors())
                DesactivateSelector(selector);
        }

        public void DesactivateSelector(ICardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.Transform.SetParent(placeHolder);
        }
    }
}
