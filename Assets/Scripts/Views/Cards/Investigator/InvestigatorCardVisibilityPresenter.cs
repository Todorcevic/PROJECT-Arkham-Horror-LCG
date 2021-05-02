using Arkham.Model;
using Zenject;
using Arkham.Adapter;
using Arkham.Services;

namespace Arkham.Views
{
    public class InvestigatorCardVisibilityPresenter : IInitializable
    {
        [Inject] private readonly RemoveInvestigatorEventDomain InvestigatorSelectorEvent;
        [Inject] private readonly AddInvestigatorEventDomain investigatorAddEvent;
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorSelectionFilter investigatorSelectionFilter;
        [Inject] private readonly CardVisibilityService visibilityService;

        /*******************************************************************/
        public void Initialize()
        {
            investigatorAddEvent.Subscribe((_) => RefreshInvestigatorsVisibility());
            InvestigatorSelectorEvent.Subscribe((_) => RefreshInvestigatorsVisibility());
        }

        /*******************************************************************/
        public void RefreshInvestigatorsVisibility()
        {
            foreach (CardView cardView in cardsManager.InvestigatorList)
            {
                bool canBeSelected = investigatorSelectionFilter.CanThisCardBeSelected(cardView.Id);
                bool canBeShowed = visibilityService.CanThisCardBeShowed(cardView.Id);
                cardView.Activate(canBeSelected);
                cardView.Show(canBeShowed);
            }
        }
    }
}
