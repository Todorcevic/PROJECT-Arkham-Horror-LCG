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
        public void ShowAllCards(Investigator investigator)
        {
            CleanAllSelectors();
            if (investigator == null) return;
            foreach (Card card in investigator.FullDeck)
                SetCardInSelector(card, investigator);

            void CleanAllSelectors()
            {
                foreach (CardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
                    DesactivateSelector(selector);
            }
        }

        public void SetCardInSelector(Card cardRow, Investigator investigator)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardRow.Id);
            int quantity = investigator.GetAmountOfThisCardInDeck(cardRow);
            selector.SetQuantity(quantity);
            SetSelector();
            if (quantity <= 0) DesactivateSelector(selector);

            void SetSelector()
            {
                if (!selector.IsEmpty) return;
                selector.SetSelector(cardRow.Id, imageCards.GetSprite(cardRow.Id));
                selector.SetName(cardRow.Name);
                selector.SetTransform(placeHolderZone);
            }
        }

        public void ChangeBackgroundColor(string investigatorId)
        {
            foreach (CardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
                selector.SetColorBackground(selectorSelectionInteractor.CanThisSelectorBeRemoved(selector.Id, investigatorId));
        }

        private void DesactivateSelector(CardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.SetTransform(selectorsZone);
        }
    }
}
