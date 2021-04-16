using Arkham.Interactors;
using Arkham.EventData;
using Zenject;
using UnityEngine;

namespace Arkham.Views
{
    public class CardSelectorPresenter : IInitializable
    {
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addCardEvent.AddAction(SetCardInSelector);
            removeCardEvent.AddAction(RemoveCardInSelector);
            selectInvestigatorEvent.AddAction(ShowAllCards);
        }

        /*******************************************************************/
        private void SetCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (selector.IsEmpty) ActivateSelector(selector, cardId);
            _ = SetQuantityAndGetIt(selector, cardId);
        }

        private void ActivateSelector(CardSelectorView selector, string cardId)
        {
            selector.SetSelector(cardId, imageCards.GetSprite(cardId));
            selector.SetName(cardInfoInteractor.GetRealName(cardId));
            selector.SetTransform(cardSelectorsManager.PlaceHolderZone);
        }

        private void RemoveCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (SetQuantityAndGetIt(selector, cardId) <= 0)
                DesactivateSelector(selector);
        }

        private int SetQuantityAndGetIt(CardSelectorView selector, string cardId)
        {
            int quantity = currentInvestigator.GetAmountOfThisCardInDeck(cardId);
            selector.SetQuantity(quantity);
            return quantity;
        }

        private void ShowAllCards(string investigatorId)
        {
            CleanAllSelectors();
            if (investigatorId == null) return;
            foreach (string cardId in investigatorInfoInteractor.GetFullDeck(investigatorId))
                SetCardInSelector(cardId);
        }

        private void CleanAllSelectors()
        {
            foreach (CardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
                DesactivateSelector(selector);
        }

        private void DesactivateSelector(CardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.SetTransform(cardSelectorsManager.SelectorsZone);
        }
    }
}