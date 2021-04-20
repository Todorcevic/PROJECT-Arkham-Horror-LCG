using Arkham.Interactors;
using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardPresenter : IInitializable
    {
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly ICardSelectorInteractors cardSelectorInteractor;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly IVisibilityEvent visibilityEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            selectInvestigatorEvent.AddAction((_) => RefreshAllCardsVisibility());
            addCardEvent.AddAction((_) => RefreshAllCardsVisibility());
            removeCardEvent.AddAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddVisibilityAction((_) => RefreshAllCardsVisibility());
            visibilityEvent.AddTextChangeAction((_) => RefreshAllCardsVisibility());
        }

        /*******************************************************************/
        private void RefreshAllCardsVisibility()
        {
            foreach (CardView cardView in cardsManager.DeckList)
            {
                bool canBeSelected = cardSelectorInteractor.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = cardSelectorInteractor.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}
