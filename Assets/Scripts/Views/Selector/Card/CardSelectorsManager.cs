using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public class CardSelectorsManager : MonoBehaviour, ICardSelectorsManager
    {
        [SerializeField, Required, SceneObjectsOnly] private RectTransform placeHoldersZone;
        [SerializeField, Required, SceneObjectsOnly] private Transform selectorsZone;
        [SerializeField, Required, SceneObjectsOnly] private List<CardSelectorView> selectors;

        public Transform PlaceHolderZone => placeHoldersZone;
        public Transform SelectorsZone => selectorsZone;
        public List<CardSelectorView> Selectors => selectors;

        /*******************************************************************/
        public List<CardSelectorView> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.Id != null);

        public CardSelectorView GetSelectorByCardIdOrEmpty(string cardId) =>
            Selectors.Find(selector => selector.Id == cardId) ?? GetEmptySelector();

        private CardSelectorView GetEmptySelector() =>
            Selectors.Find(selector => selector.Id == null);
    }
}
