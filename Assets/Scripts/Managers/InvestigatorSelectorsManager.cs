using Arkham.Repositories;
using Arkham.UI;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : MonoBehaviour
    {
        private InvestigatorSelectorController currentSelectorSelected;
        [Inject] private readonly ISelectorRepository selectorRepository;
        [Inject] private readonly ICardComponentRepository cardRepository;
        [SerializeField, Required, ChildGameObjectsOnly] private Transform placeHolder;
        [SerializeField, Required, ChildGameObjectsOnly] private List<InvestigatorSelectorController> Selectors;

        public List<string> InvestigatorsSelected => selectorRepository.InvestigatorsSelectedList;

        /*******************************************************************/
        private void Start()
        {
            foreach (InvestigatorSelectorController selector in Selectors)
            {
                selector.Interactable.AddClickAction(() => SelectSelector(selector));
                selector.Interactable.AddDoubleClickAction(() => RemoveSelector(selector));
            }

            foreach (string investigatorId in InvestigatorsSelected)
                GetVoidSelector().SetInvestigator(cardRepository.GetInvestigator(investigatorId));
            SortSelectors();
        }

        public void SelectSelector(InvestigatorSelectorController selector)
        {
            currentSelectorSelected?.ActivateGlow(false);
            selector.ActivateGlow(true);
            currentSelectorSelected = selector;
        }

        public void AddInvestigator(CardInvestigatorController investigator)
        {
            InvestigatorsSelected.Add(investigator.Id);
            InvestigatorSelectorController selector = GetVoidSelector();
            selector.SetInvestigator(investigator);
            selector.MoveTo(investigator.Transform);
            SortSelectors();
        }

        public void RemoveSelector(InvestigatorSelectorController selector)
        {
            InvestigatorsSelected.Remove(selector.Investigator.Id);
            selector.Investigator.UpdateVisualState();
            selector.SetInvestigator(null);
            SortSelectors();
        }

        private void SortSelectors()
        {
            foreach (InvestigatorSelectorController selector in Selectors)
                selector.SortIn(selector.IsEmpty ? selector.transform : placeHolder);
        }

        private InvestigatorSelectorController GetVoidSelector() =>
            Selectors.Find(s => s.Investigator == null);
    }
}
