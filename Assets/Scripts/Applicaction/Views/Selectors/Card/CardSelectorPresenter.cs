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
        [Inject] private readonly ICardImage imageCards;

        /*******************************************************************/
        public void CantRemove(string cardId) => cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId).CantRemoveAnimation();

        public void ShowAllCards(List<CardRowDTO> allCards)
        {
            CleanAllSelectors();
            foreach (CardRowDTO cardRow in allCards)
                SetCardInSelector(cardRow);
        }

        public void SetCardInSelector(CardRowDTO cardRow)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardRow.Id);
            selector.SetQuantity(cardRow.Quantity);
            SetSelector(selector, cardRow);
            if (cardRow.Quantity <= 0) DesactivateSelector(selector);
        }

        private void SetSelector(CardSelectorView selector, CardRowDTO cardRow)
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
