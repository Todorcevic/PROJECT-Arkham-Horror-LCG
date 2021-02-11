using Arkham.Repositories;
using Arkham.UI;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : IInvestigatorSelectorsManager
    {
        [Inject] private readonly ISelectorRepository selectorRepository;
        [Inject] private readonly InvestigatorSelectorComponent components;
        [Inject] private readonly CardRepository cardRepository;
        private List<string> InvestigatorsSelected => selectorRepository.InvestigatorsSelectedList;
        private List<InvestigatorSelectorView> Selectors => components.Selectors;
        private Transform PlaceHolder => components.PlaceHolder;

        /*******************************************************************/
        public void Init()
        {
            foreach (string investigatorId in InvestigatorsSelected)
                SetSelector(investigatorId);
            OrderSelectors();
        }

        public void AddInvestigator(CardView investigator)
        {
            SetSelector(investigator);
            GetSelectorByInvestigator(investigator.Id).transform.position = investigator.Transform.position;
            OrderSelectors();
            InvestigatorsSelected.Add(investigator.Id);
        }

        public void RemoveSelector(InvestigatorSelectorView selector)
        {
            InvestigatorsSelected.Remove(selector.InvestigatorId);
            selector.SetInvestigator(null);
            OrderSelectors();
        }

        private void SetSelector(string investigatorId)
        {
            CardView cardView = cardRepository.GetCardView(investigatorId);
            SetSelector(cardView);
        }

        private void SetSelector(CardView investigator) => GetVoidSelector().SetInvestigator(investigator);

        private void OrderSelectors()
        {
            foreach (InvestigatorSelectorView selector in Selectors)
            {
                selector.MovePlaceHolder(selector.IsEmpty ? selector.transform : PlaceHolder);
                selector.StartCoroutine(selector.Reorder());
            }
        }

        private InvestigatorSelectorView GetVoidSelector() =>
            Selectors.Find(s => s.InvestigatorId == null);
        private InvestigatorSelectorView GetSelectorByInvestigator(string investigatorId) =>
            Selectors.Find(s => s.InvestigatorId == investigatorId);
    }
}
