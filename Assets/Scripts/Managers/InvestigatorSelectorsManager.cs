using Arkham.Controllers;
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
        private IInvestigatorSelectorView currentSelectorSelected;
        [Inject] private readonly InvestigatorSelectorComponent components;
        [Inject] private readonly ISelectorRepository selectorRepository;
        [Inject] private readonly ICardComponentRepository cardRepository;
        [Inject] private readonly ICardInvestigatorController cardController;

        private List<string> InvestigatorsSelected => selectorRepository.InvestigatorsSelectedList;
        private List<IInvestigatorSelectorView> Selectors => components.Selectors;
        private Transform PlaceHolder => components.PlaceHolder;

        /*******************************************************************/
        public void Init()
        {
            foreach (string investigatorId in InvestigatorsSelected)
                SetSelector(investigatorId);
            OrderSelectors();
        }

        public void SelectSelector(IInvestigatorSelectorView selectorView)
        {
            currentSelectorSelected?.ActivateGlow(false);
            selectorView.ActivateGlow(true);
            currentSelectorSelected = selectorView;
        }

        public void AddInvestigator(ICardView investigator)
        {
            InvestigatorsSelected.Add(investigator.Id);
            cardController.UpdateVisualState(investigator);
            SetSelector(investigator);
            GetSelectorByInvestigator(investigator.Id).Transform.position = investigator.Transform.position;
            OrderSelectors();
        }

        public void RemoveSelector(IInvestigatorSelectorView selector)
        {
            InvestigatorsSelected.Remove(selector.InvestigatorId);
            cardController.UpdateVisualState(cardRepository.AllCardComponents[selector.InvestigatorId]);
            selector.SetInvestigator(null);
            OrderSelectors();
        }

        private void SetSelector(string investigatorId)
        {
            ICardView cardView = cardRepository.AllCardComponents[investigatorId];
            SetSelector(cardView);
        }

        private void SetSelector(ICardView investigator) => GetVoidSelector().SetInvestigator(investigator);

        private void OrderSelectors()
        {
            foreach (IInvestigatorSelectorView selector in Selectors)
            {
                selector.MovePlaceHolder(selector.IsEmpty ? selector.Transform : PlaceHolder);
                components.StartCoroutine(selector.Reorder());
            }
        }

        private IInvestigatorSelectorView GetVoidSelector() =>
            Selectors.Find(s => s.InvestigatorId == null);
        private IInvestigatorSelectorView GetSelectorByInvestigator(string investigatorId) =>
            Selectors.Find(s => s.InvestigatorId == investigatorId);
    }
}
