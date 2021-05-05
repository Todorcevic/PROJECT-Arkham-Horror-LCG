using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardVisibilityPresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectionInteractor investigatorSelectionFilter;
        [Inject] private readonly CardVisibilityInteractor visibilityService;

        /*******************************************************************/
        public void RefreshInvestigatorsVisibility()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id);
                cardView.Show(canBeShowed);
            }
        }

        public void RefreshInvestigatorsSelectability()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeSelected = investigatorSelectionFilter.CanThisCardBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }
    }
}
