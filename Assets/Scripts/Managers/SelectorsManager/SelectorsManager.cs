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
        protected List<ISelectorView> Selectors => selectors.OfType<ISelectorView>().ToList();

        /*******************************************************************/
        public ISelectorView GetVoidSelector() =>
            Selectors.Find(selector => selector.CardInThisSelector == null);
    }
}
