using Arkham.Models;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Arkham.Managers
{
    public class InvestigatorSelectorComponent : MonoBehaviour
    {
        [SerializeField] private List<Transform> placeHolders;
        [SerializeField] private List<InvestigatorSelectorView> selectors;

        public void OrderSelectors(int quantity)
        {
            int i = 0;
            foreach (Transform placeHolder in placeHolders)
            {
                placeHolder.gameObject.SetActive(i <= quantity);
                i++;
            }

            i = 0;
            foreach (InvestigatorSelectorView selector in selectors)
            {
                selector.transform.DOMove(placeHolders[i].position, 0.25f);
                i++;
            }
        }
    }
}
