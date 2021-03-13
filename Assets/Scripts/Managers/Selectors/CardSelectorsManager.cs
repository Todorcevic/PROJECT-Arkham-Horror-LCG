using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public class CardSelectorsManager : MonoBehaviour, ICardSelectorsManager
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolderZone;
        [SerializeField, Required, SceneObjectsOnly] private Transform selectorsZone;
        [SerializeField, Required, SceneObjectsOnly] private List<CardSelectorView> selectors;

        public Transform PlaceHolderZone => placeHolderZone;
        public Transform SelectorsZone => selectorsZone;
        public List<CardSelectorView> Selectors => selectors;

        /*******************************************************************/
        public List<CardSelectorView> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.Id != null);

        public CardSelectorView GetSelectorByCardIdOrEmpty(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId) ?? GetEmptySelector();

        private CardSelectorView GetEmptySelector() =>
            Selectors.Find(selector => selector.Id == null);

        public void CleanAllSelectors()
        {
            foreach (CardSelectorView selector in GetAllFilledSelectors())
                DesactivateSelector(selector);
        }

        public void DesactivateSelector(CardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.SelectorMovement.SetTransform(selectorsZone);
        }
    }
}
