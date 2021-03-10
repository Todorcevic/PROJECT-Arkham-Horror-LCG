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
        public List<ICardSelector> Selectors =>
            selectors.OfType<ICardSelector>().ToList();

        /*******************************************************************/
        public List<ICardSelector> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.Id != null);

        public ICardSelector GetSelectorByCardIdOrEmpty(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId) ?? GetEmptySelector();

        private ICardSelector GetEmptySelector() =>
            Selectors.Find(selector => selector.Id == null);

        public void CleanAllSelectors()
        {
            foreach (ICardSelector selector in GetAllFilledSelectors())
                DesactivateSelector(selector);
        }

        public void DesactivateSelector(ICardSelector selector)
        {
            selector.SetSelector(null);
            //selector.Transform.SetParent(placeHolder);
        }
    }
}
