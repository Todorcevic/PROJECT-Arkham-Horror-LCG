using Arkham.Model;
using Arkham.Services;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardAddPresenter : IInitializable, ICardAddPresenter
    {
        [Inject(Id = "CardPlaceHolderZone")] public RectTransform placeHolderZone;
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IImageCardsManager imageCards;
        [Inject] private readonly CardRepository cardCollection;
        [Inject] private readonly Selector selector;

        /*******************************************************************/
        public void Initialize() => addCardEvent.Subscribe(SetCardInSelector);

        /*******************************************************************/
        public void SetCardInSelector(string cardId)
        {
            CardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (selector.IsEmpty) ActivateSelector(selector, cardId);
            SetQuantity(selector);
        }

        private void ActivateSelector(CardSelectorView selector, string cardId)
        {
            selector.SetSelector(cardId, imageCards.GetSprite(cardId));
            selector.SetName(cardCollection.Get(cardId).Real_name);
            selector.SetTransform(placeHolderZone);
        }

        private void SetQuantity(CardSelectorView selector)
        {
            int quantity = this.selector.InvestigatorSelected.GetAmountOfThisCardInDeck(selector.Id);
            selector.SetQuantity(quantity);
        }
    }
}
