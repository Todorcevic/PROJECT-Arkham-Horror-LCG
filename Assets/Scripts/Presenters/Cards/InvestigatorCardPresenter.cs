using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorCardPresenter : IInvestigatorCardPresenter
    {
        [Inject] protected readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;

        /*******************************************************************/
        public void Init()
        {
            investigatorSelectorInteractor.InvestigatorAdded += ResolveAddVisibility;
            investigatorSelectorInteractor.InvestigatorRemoved += ResolveRemoveVisibility;
            RefreshAllCardsVisibility();
        }

        private void ResolveAddVisibility(string investigatorId)
        {
            if (investigatorSelectorInteractor.SelectionIsFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        private void ResolveRemoveVisibility(string investigatorId)
        {
            if (investigatorSelectorInteractor.SelectionIsNotFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        private void RefreshCardVisibility(string cardId) =>
            investigatorCardsManager.AllCards[cardId].Activate(CheckIsEnable(cardId));

        private void RefreshAllCardsVisibility()
        {
            foreach (ICardView cardView in investigatorCardsManager.CardsList)
                cardView.Activate(CheckIsEnable(cardView.Id));
        }

        private bool CheckIsEnable(string cardId)
        {
            if (investigatorSelectorInteractor.SelectionIsFull) return false;
            if (((cardInfoInteractor.GetCardInfo(cardId).Quantity ?? 0) - AmountCardsSelected(cardId)) <= 0) return false;
            return true;
        }

        private int AmountCardsSelected(string cardId) =>
            investigatorSelectorInteractor.InvestigatorsSelectedList.FindAll(i => i == cardId).Count;
    }
}
