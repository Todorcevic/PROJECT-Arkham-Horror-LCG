﻿using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using Zenject;

namespace Arkham.Presenters
{
    public class DeckCardPresenter : IInitializable
    {
        [Inject] protected readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject(Id = "DeckCardsManager")] private readonly ICardsManager deckCardsManager;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            investigatorSelectorInteractor.InvestigatorSelectedChanged += RefreshAllCardsVisibility;
            deckBuilderInteractor.DeckCardAdded += ResolveAddVisibility;
            deckBuilderInteractor.DeckCardRemoved += ResolveRemoveVisibility;
        }

        /*******************************************************************/
        private void ResolveAddVisibility(string cardId)
        {
            if (deckBuilderInteractor.SelectionIsFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(cardId);
        }

        private void ResolveRemoveVisibility(string cardId)
        {
            if (deckBuilderInteractor.SelectionIsNotFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(cardId);
        }

        private void RefreshCardVisibility(string cardId) =>
            deckCardsManager.AllCards[cardId].Activate(CheckIsEnable(cardId));

        private void RefreshAllCardsVisibility(string _) => RefreshAllCardsVisibility();

        private void RefreshAllCardsVisibility()
        {
            foreach (ICardView cardView in deckCardsManager.CardsList)
                cardView.Activate(CheckIsEnable(cardView.Id));
        }

        private bool CheckIsEnable(string cardId)
        {
            if (deckBuilderInteractor.SelectionIsFull) return false;
            if ((cardInfoInteractor.GetCardInfo(cardId).Quantity ?? 0) - deckBuilderInteractor.AmountSelectedOfThisCard(cardId) <= 0) return false;
            return true;
        }


    }
}
