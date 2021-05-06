using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class DeckCardVisibilityPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly CardSelectionInteractor cardSelectionFilter;
        [Inject] private readonly CardVisibilityInteractor visibilityService;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;

        /*******************************************************************/
        public void RefreshCardsVisibility()
        {
            foreach (CardView cardView in cardsManager.DeckList)
            {
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Show(canBeShowed);
            }
        }

        public void RefreshCardsSelectability()
        {
            foreach (CardView cardView in cardsManager.DeckList)
            {
                bool canBeSelected = cardSelectionFilter.CanThisCardBeSelected(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);
                cardView.Activate(canBeSelected);
            }
        }
    }
}
