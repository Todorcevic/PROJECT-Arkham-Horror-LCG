using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.EventData;
using Zenject;
using Arkham.Views;

namespace Arkham.Presenters
{
    public class CardSelectorPresenter : IInitializable
    {
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly IDeckCardsManager deckCardsManager;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly ICurrentInvestigator currentInvestigator;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addCardEvent.DeckCardAdded += SetCardInSelector;
            removeCardEvent.DeckCardRemoved += RemoveCardInSelector;
            selectInvestigatorEvent.InvestigatorSelectedChanged += ShowAllCards;
        }

        /*******************************************************************/
        private void SetCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (selector.IsEmpty) ActivateSelector(selector, cardId);
            _ = SetQuantityAndGetIt(selector, cardId);
        }

        private void RemoveCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (SetQuantityAndGetIt(selector, cardId) <= 0)
                cardSelectorsManager.DesactivateSelector(selector);
        }

        private void ActivateSelector(CardSelectorView selector, string cardId)
        {
            selector.SetSelector(cardId, imageCards.GetSprite(cardId));
            selector.TextRefresher.SetName(cardInfoInteractor.GetRealName(cardId));
            selector.SelectorMovement.SetTransform(cardSelectorsManager.PlaceHolderZone);
            selector.SelectorMovement.MoveImageTo(cardSelectorsManager.PlaceHolderZone);
            selector.SelectorMovement.Arrange();

        }

        private int SetQuantityAndGetIt(CardSelectorView selector, string cardId)
        {
            int quantity = currentInvestigator.GetAmountOfThisCardInDeck(cardId);
            selector.TextRefresher.SetQuantity(quantity);
            return quantity;
        }

        private void ShowAllCards(string investigatorId)
        {
            cardSelectorsManager.CleanAllSelectors();
            if (investigatorId == null) return;
            foreach (string cardId in investigatorInfoInteractor.GetFullDeck(investigatorId))
                SetCardInSelector(cardId);
        }
    }
}