﻿using Arkham.Model;
using Arkham.Services;
using Zenject;

namespace Arkham.Application
{
    public class DeckCardPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;
        [Inject] private readonly CardVisibilityInteractor visibilityService;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly CardRepository cardRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly CardShowerPresenter cardShower;

        /*******************************************************************/
        public void RefreshCardsVisibility()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                if (!canBeShowed) cardShower.HoveredOff(cardView.Id);
                cardView.Show(canBeShowed);
            }
        }

        public void RefreshCardsSelectability()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                bool canBeSelected = cardSelectionFilter.CanThisCardBeSelected(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Activate(canBeSelected);
            }
        }

        public void RefresQuantity()
        {
            foreach (DeckCardView cardView in cardsManager.DeckList)
            {
                Card card = cardRepository.Get(cardView.Id);
                int quantity = investigatorRepository.AmountLeftOfThisCard(card);
                cardView.SetQuantity(FormatQuantity(quantity));
            }
        }

        public void SetQuantity(Card card)
        {
            int quantity = investigatorRepository.AmountLeftOfThisCard(card);
            cardsManager.GetDeckCard(card.Id).SetQuantity(FormatQuantity(quantity));
        }

        private string FormatQuantity(int quantity) => quantity > 1 ? "x" + quantity : string.Empty;
    }
}
