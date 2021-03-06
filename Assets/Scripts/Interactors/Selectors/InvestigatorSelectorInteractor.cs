﻿using Arkham.Config;
using Arkham.Repositories;
using System.Linq;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorSelectorInteractor : IInvestigatorSelectorInteractor
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;

        public string LeadInvestigator => investigatorSelectorRepository.InvestigatorsSelectedList.FirstOrDefault();
        public bool SelectionIsFull => investigatorSelectorRepository.InvestigatorsSelectedList.Count >= GameData.MAX_INVESTIGATORS;

        /*******************************************************************/
        public bool CanThisCardBeSelected(string cardId)
        {
            if (SelectionIsFull) return false;
            if (IsThisCardWasted(cardId)) return false;
            return true;
        }

        private int AmountSelectedOfThisCard(string cardId) =>
            investigatorSelectorRepository.InvestigatorsSelectedList.FindAll(i => i == cardId).Count;

        private bool IsThisCardWasted(string cardId) => cardInfoInteractor.GetQuantity(cardId) - AmountSelectedOfThisCard(cardId) <= 0;
    }
}
