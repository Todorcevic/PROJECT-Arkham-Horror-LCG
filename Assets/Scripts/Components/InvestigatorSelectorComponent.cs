using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.UI
{
    public class InvestigatorSelectorComponent : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorSelectorView> selectors;

        public Transform PlaceHolder => placeHolder;
        public List<InvestigatorSelectorView> Selectors => selectors;
    }
}
