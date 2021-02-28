using Arkham.Components;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using System.Collections;
using System.Linq;
using Zenject;

namespace Arkham.Presenters
{
    public class CardSelectorPresenter : IInitializablePresenter
    {
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IImageCardsManager imageCards;
        IEnumerable IInitializablePresenter.interactableViews =>
            cardSelectorsManager.Selectors.OfType<IInteractableView>();

        /*******************************************************************/
        void IInitializablePresenter.Init()
        {
            deckBuilderInteractor.DeckCardAdded += SetCardInSelector;
            deckBuilderInteractor.DeckCardRemoved += RemoveCardInSelector;
            investigatorSelectorInteractor.InvestigatorSelectedChanged += ShowAllCards;
        }

        private void SetCardInSelector(string cardId)
        {
            ICardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (selector.IsEmpty) ActivateSelector(selector, cardId);
            _ = SetQuantityAndGetIt(selector, cardId);
        }

        private void RemoveCardInSelector(string cardId)
        {
            ICardSelectorView selector = cardSelectorsManager.GetSelectorByCardIdOrEmpty(cardId);
            if (SetQuantityAndGetIt(selector, cardId) <= 0) cardSelectorsManager.DesactivateSelector(selector);
        }

        private void ActivateSelector(ICardSelectorView selector, string cardId)
        {
            selector.SetSelector(cardId, imageCards.GetSprite(cardId));
            selector.SetName(cardInfoInteractor.GetCardInfo(cardId).Real_name);
            selector.Transform.SetParent(cardSelectorsManager.Zone);
        }

        private int SetQuantityAndGetIt(ICardSelectorView selector, string cardId)
        {
            int quantity = investigatorInfoInteractor.GetThisCardAmountInDeck(investigatorSelectorInteractor.InvestigatorSelected, cardId);
            selector.SetQuantity(quantity);
            return quantity;
        }

        private void ShowAllCards(string investigatorId)
        {
            cardSelectorsManager.CleanAllSelectors();
            foreach (string cardId in investigatorInfoInteractor.GetFullDeck(investigatorId))
                SetCardInSelector(cardId);
        }
    }
}
