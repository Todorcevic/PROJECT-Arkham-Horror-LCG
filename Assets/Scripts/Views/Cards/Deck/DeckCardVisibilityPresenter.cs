using Arkham.Model;
using Zenject;
using Arkham.Adapter;
using Arkham.Services;

namespace Arkham.Views
{
    public class DeckCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly CardSelectionFiler cardSelectionFilter;
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly RemoveCardEventDomain cardRemovedEvent;
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly CardVisibilityService visibilityService;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            investigatorSelectEvent.Subscribe((_) => RefreshCardsVisibility());
            addCardEvent.Subscribe((_) => RefreshCardsVisibility());
            cardRemovedEvent.Subscribe((_) => RefreshCardsVisibility());
        }

        /*******************************************************************/
        public void RefreshCardsVisibility()
        {
            foreach (CardView cardView in cardsManager.DeckList)
            {
                bool canBeSelected = cardSelectionFilter.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}
