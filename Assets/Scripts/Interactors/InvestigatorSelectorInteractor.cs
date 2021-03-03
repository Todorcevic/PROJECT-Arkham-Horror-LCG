using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorSelectorInteractor : IInvestigatorSelectorInteractor
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] protected readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] protected readonly IDeckBuilderInteractor deckBuilderInteractor;
        public event Action<string> InvestigatorSelectedChanged;
        public event Action<string> InvestigatorAdded;
        public event Action<string> InvestigatorRemoved;
        public string InvestigatorSelected { get; private set; }
        public string LeadInvestigator => investigatorSelectorRepository.InvestigatorsSelectedList.FirstOrDefault();
        public bool SelectionIsFull => InvestigatorsSelectedList.Count >= GameData.MAX_INVESTIGATORS;
        public bool SelectionIsNotFull => InvestigatorsSelectedList.Count == GameData.MAX_INVESTIGATORS - 1;
        public List<string> InvestigatorsSelectedList => investigatorSelectorRepository.InvestigatorsSelectedList;

        /*******************************************************************/
        public void SelectInvestigator(string investigatorId)
        {
            InvestigatorSelected = investigatorId;
            InvestigatorSelectedChanged?.Invoke(investigatorId);
        }

        public void AddInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Add(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
            SelectInvestigator(investigatorId);
        }

        public void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Remove(investigatorId);
            InvestigatorRemoved?.Invoke(investigatorId);
            SelectInvestigator(investigatorSelectorRepository.InvestigatorsSelectedList.FirstOrDefault());
        }

        public void SelectLeadInvestigator() => SelectInvestigator(LeadInvestigator);

        public bool CanBeSelected(string cardId)
        {
            if (SelectionIsFull) return false;
            if (((cardInfoInteractor.GetQuantity(cardId)) - AmountSelectedOfThisCard(cardId)) <= 0) return false;
            return true;
        }

        private int AmountSelectedOfThisCard(string cardId) => InvestigatorsSelectedList.FindAll(i => i == cardId).Count;
    }
}
