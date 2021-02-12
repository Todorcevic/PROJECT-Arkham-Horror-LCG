using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.UI
{
    public class InvestigatorSelectorComponent : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorSelectorView> selectors;

        public Transform PlaceHolder => placeHolder;
        public List<IInvestigatorSelectorView> Selectors => selectors.OfType<IInvestigatorSelectorView>().ToList();
    }
}
