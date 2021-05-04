using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardVisibilityPresenter
    {
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly CardVisibilityInteractor visibilityService;

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
