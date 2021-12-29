using Arkham.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardSelectorPresenter
    {
        [Inject(Id = "CardSelectorZone")] private readonly RectTransform selectorsZone;
        [Inject(Id = "CardPlaceHolderZone")] private readonly RectTransform placeHolderZone;
        [Inject] private readonly CardSelectorsManager cardSelectorsManager;
        [Inject] private readonly SelectorSelectionInteractor selectorSelectionInteractor;
        [Inject] private readonly ImagesCardService imageCards;

        /*******************************************************************/
        public void ShowAllCards(Investigator investigator)
        {
            CleanAllSelectors();
            if (investigator != null) SetAllCards();

            void SetAllCards() => investigator.FullDeck.ForEach(cardInfo => SetCardInSelector(cardInfo, investigator));
            void CleanAllSelectors() => cardSelectorsManager.GetAllFilledSelectors().ForEach(selector => DesactivateSelector(selector));
        }

        public CardSelectorView SetCardInSelector(CardInfo cardRow, Investigator investigator)
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
