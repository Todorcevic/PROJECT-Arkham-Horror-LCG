using Arkham.Model;
using Arkham.Services;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Application
{
    public class CardSelectorPresenter
    {
        [Inject(Id = "CardSelectorZone")] public RectTransform selectorsZone;
        [Inject(Id = "CardPlaceHolderZone")] public RectTransform placeHolderZone;
        [Inject] private readonly CardSelectorsManager cardSelectorsManager;
        [Inject] private readonly SelectorSelectionInteractor selectorSelectionInteractor;
        [Inject] private readonly ICardImage imageCards;

        [Inject] private readonly InvestigatorRepository investigatorRepository;

        /*******************************************************************/
        public void CantRemove(string cardId) => cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId).CantRemoveAnimation();

        public void ShowAllCards(Investigator investigator)
        {
            if (investigator == null) return;
            CleanAllSelectors();
            foreach (Card card in investigator?.FullDeck)
                SetCardInSelector(card);
        }

        public void SetCardInSelector(Card cardRow)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardRow.Id);
            selector.SetQuantity(cardRow.Quantity ?? 0);
            SetSelector(selector, cardRow);
            if (cardRow.Quantity <= 0) DesactivateSelector(selector);
        }

        public void ChangeBackgroundColor(string investigatorId)
        {
            foreach (CardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
                selector.SetColorBackground(selectorSelectionInteractor.CanThisSelectorBeRemoved(selector.Id, investigatorId));
        }

        private void SetSelector(CardSelectorView selector, Card cardRow)
        {
            if (!selector.IsEmpty) return;
            selector.SetSelector(cardRow.Id, imageCards.GetSprite(cardRow.Id));
            selector.SetName(cardRow.Name);
            selector.SetTransform(placeHolderZone);
        }

        private void CleanAllSelectors()
        {
            foreach (CardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
                DesactivateSelector(selector);
        }

        private void DesactivateSelector(CardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.SetTransform(selectorsZone);
        }
    }
}
