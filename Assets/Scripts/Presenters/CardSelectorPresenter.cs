using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Models;
using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Presenters
{
    public class CardSelectorPresenter : ICardSelectorPresenter
    {
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IImagesCard imageCards;
        public List<ICardSelectorView> Selectors => cardSelectorsManager.Selectors;

        /*******************************************************************/
        public void Init()
        {
            deckBuilderInteractor.DeckCardAdded += SetCardInSelector;
            deckBuilderInteractor.DeckCardRemoved += RemoveCardInSelector;
            investigatorSelectorInteractor.InvestigatorSelectedChanged += ShowAllCards;
        }

        private void SetCardInSelector(string cardId)
        {
            int quantity = investigatorInfoInteractor.GetThisCardAmountInDeck(investigatorSelectorInteractor.InvestigatorSelected, cardId);
            ICardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (selector.IsEmpty)
            {
                selector.SetSelector(cardId, imageCards.GetSprite(cardId));
                ActivateSelector(selector);
                selector.SetName(cardInfoInteractor.GetCardInfo(cardId).Real_name);
            }
            selector.SetQuantity(quantity);
        }

        private void RemoveCardInSelector(string cardId)
        {
            ICardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            int quantity = investigatorInfoInteractor.GetThisCardAmountInDeck(investigatorSelectorInteractor.InvestigatorSelected, cardId);
            if (quantity <= 0)
            {
                selector.SetSelector(null);
                DesactivateSelector(selector);
            }
            selector.SetQuantity(quantity);
        }

        private void ActivateSelector(ICardSelectorView selector) =>
            selector.Transform.SetParent(cardSelectorsManager.Zone);

        private void DesactivateSelector(ICardSelectorView selector) =>
            selector.Transform.SetParent(cardSelectorsManager.PlaceHolder);

        private void ShowAllCards(string investigatorId)
        {
            CleanAllSelectors();
            foreach (string cardId in investigatorInfoInteractor.GetFullDeck(investigatorId))
                SetCardInSelector(cardId);
        }

        private void CleanAllSelectors()
        {
            foreach (ICardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
            {
                selector.SetSelector(null);
                DesactivateSelector(selector);
            }
        }
    }
}
