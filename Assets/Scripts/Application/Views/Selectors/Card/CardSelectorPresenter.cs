using Arkham.Model;
using Arkham.Services;
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

        /*******************************************************************/
        public void CantRemove(string cardId) => cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId).CantRemoveAnimation();

        public void ShowAllCards(Investigator investigator)
        {
            CleanAllSelectors();
            if (investigator == null) return;
            foreach (Card card in investigator.FullDeck)
                SetCardInSelector(card, investigator);
        }

        public void SetCardInSelector(Card cardRow, Investigator investigator)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardRow.Id);
            int quantity = investigator.GetAmountOfThisCardInDeck(cardRow);
            selector.SetQuantity(quantity);
            SetSelector(selector, cardRow);
            if (quantity <= 0) DesactivateSelector(selector);
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
