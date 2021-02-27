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
        [Inject] private readonly IInvestigatorSelectorInteractor selectorInteractor;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;
        private bool SelectionIsFull => selectorInteractor.InvestigatorsSelectedList.Count >= GameData.MAX_INVESTIGATORS;
        private bool SelectionIsNotFull => selectorInteractor.InvestigatorsSelectedList.Count == GameData.MAX_INVESTIGATORS - 1;
        public List<IInvestigatorCardView> InvestigatorCardsList => investigatorCardsManager.CardsList.OfType<IInvestigatorCardView>().ToList();

        /*******************************************************************/
        public void Init()
        {
            selectorInteractor.InvestigatorAdded += ResolveAddVisibility;
            selectorInteractor.InvestigatorRemoved += ResolveRemoveVisibility;
            RefreshAllCardsVisibility();
        }

        public void RefreshCardVisibility(string cardId) =>
            investigatorCardsManager.AllCards[cardId].Activate(CheckIsEnable(cardId));

        public void RefreshAllCardsVisibility()
        {
            foreach (ICardView cardView in InvestigatorCardsList)
                cardView.Activate(CheckIsEnable(cardView.Id));
        }

        private bool CheckIsEnable(string cardId)
        {
            if (SelectionIsFull) return false;
            if (((cardInfoInteractor.GetCardInfo(cardId).Quantity ?? 0) - AmountCardsSelected(cardId)) <= 0) return false;
            return true;
        }

        private void ResolveAddVisibility(string investigatorId)
        {
            if (SelectionIsFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        private void ResolveRemoveVisibility(string investigatorId)
        {
            if (SelectionIsNotFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        private int AmountCardsSelected(string cardId) =>
            selectorInteractor.InvestigatorsSelectedList.FindAll(i => i == cardId).Count;
    }
}
