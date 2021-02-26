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
    public class SelectorsManager : MonoBehaviour, ISelectorsManager
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, SceneObjectsOnly] private List<SelectorView> selectors;
        public Transform PlaceHolder => placeHolder;

        /*******************************************************************/
        public List<T> Selectors<T>() where T : ISelectorView => selectors.OfType<T>().ToList();

        public T GetEmptySelector<T>() where T : ISelectorView =>
            Selectors<T>().Find(selector => selector.CardInThisSelector == null);

        public List<T> GetAllFilledSelectors<T>() where T : ISelectorView =>
            Selectors<T>().FindAll(selector => selector.CardInThisSelector != null);

        public T GetSelectorById<T>(string cardId) where T : ISelectorView =>
            Selectors<T>().Find(selector => selector.CardInThisSelector == cardId);
    }
}
