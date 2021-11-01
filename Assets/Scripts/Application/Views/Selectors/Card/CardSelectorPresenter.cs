using Arkham.Model;
using Arkham.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardSelectorPresenter
    {
        [Inject(Id = "CardSelectorZone")] private readonly RectTransform selectorsZone;
        [Inject(Id = "CardPlaceHolderZone")] private readonly RectTransform placeHolderZone;
        [Inject] private readonly CardSelectorsManager cardSelectorsManager;
        [Inject] private readonly SelectorSelectionInteractor selectorSelectionInteractor;
        [Inject] private readonly ICardImage imageCards;

        /*******************************************************************/
        public void ShowAllCards(Investigator investigator)
        {
            CleanAllSelectors();
            if (investigator != null) SetAllCards();

            void SetAllCards() => investigator.FullDeck.ForEach(i => SetCardInSelector(i, investigator));
            void CleanAllSelectors() => cardSelectorsManager.GetAllFilledSelectors().ForEach(selector => DesactivateSelector(selector));
        }

        public CardSelectorView SetCardInSelector(Card cardRow, Investigator investigator)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardRow.Id);
            int quantity = investigator.GetAmountOfThisCardInDeck(cardRow);
            selector.SetQuantity(quantity);
            SetSelector();
            if (quantity <= 0) DesactivateSelector(selector);
            return selector;

            void SetSelector()
            {
                if (!selector.IsEmpty) return;
                selector.SetSelector(cardRow.Id, imageCards.GetSprite(cardRow.Id));
                selector.SetName(cardRow.Name);
                selector.SetTransform(placeHolderZone);
                LayoutRebuilder.ForceRebuildLayoutImmediate(placeHolderZone);
                selector.ShowAnimation();
            }
        }

        public void SetCanBeRemovedInSelectors(string investigatorId)
        {
            foreach (CardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
                selector.SetCanBeRemoved(selectorSelectionInteractor.CanThisSelectorBeRemoved(selector.Id, investigatorId));
        }

        private void DesactivateSelector(CardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.SetTransform(selectorsZone);
        }
    }
}
