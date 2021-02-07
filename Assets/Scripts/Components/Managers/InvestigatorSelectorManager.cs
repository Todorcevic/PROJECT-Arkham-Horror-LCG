using Arkham.Models;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
using Arkham.Presenters;

namespace Arkham.Managers
{
    public class InvestigatorSelectorManager : MonoBehaviour, IInvestigatorSelectorManager
    {
        private InvestigatorSelectorView currentSelected;
        [Inject] private IPresenter<IInvestigatorSelectorManager> presenter;
        [SerializeField] private List<Transform> placeHolders;
        [SerializeField] private List<InvestigatorSelectorView> selectors;

        /*******************************************************************/
        private void Start()
        {
            presenter.CreateReactiveViewModel(this);
        }

        /*******************************************************************/
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

        public void ActivateSelector(int idSelector)
        {
            currentSelected?.ActivateGlow(false);
            if (idSelector >= 0 && idSelector < selectors.Count)
            {
                selectors[idSelector].ActivateGlow(true);
                currentSelected = selectors[idSelector];
            }
        }

        public void ChangeImage(int idSelector, Sprite sprite)
        {
            selectors[idSelector].ChangeImage(sprite);
        }
    }
}
