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
        public Transform PlaceHolder => placeHolder;
        public List<ICardSelectorView> Selectors =>
            selectors.OfType<ICardSelectorView>().ToList();

        /*******************************************************************/
        public List<ICardSelectorView> GetAllFilledSelectors() =>
            Selectors.FindAll(selector => selector.CardInThisSelector != null);

        public ICardSelectorView GetSelectorByCardIdOrEmpty(string cardId) =>
            Selectors.Find(selector => selector.CardInThisSelector == cardId) ?? GetEmptySelector();

        private ICardSelectorView GetEmptySelector() =>
            Selectors.Find(selector => selector.CardInThisSelector == null);
    }
}
