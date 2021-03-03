using Arkham.Interactors;
using Arkham.Managers;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorCardPresenter : IInitializable
    {
        [Inject] protected readonly ICardInfoInteractor cardInfoInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly IInvestigatorCardsManager investigatorCardsManager;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            investigatorSelectorInteractor.InvestigatorAdded += ResolveAddVisibility;
            investigatorSelectorInteractor.InvestigatorRemoved += ResolveRemoveVisibility;
            RefreshAllCardsVisibility();
        }

        /*******************************************************************/
        private void ResolveAddVisibility(string investigatorId)
        {
            if (investigatorSelectorInteractor.SelectionIsFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        private void ResolveRemoveVisibility(string investigatorId)
        {
            if (investigatorSelectorInteractor.SelectionIsNotFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        private void RefreshCardVisibility(string cardId)
        {
            bool canBeSelected = investigatorSelectorInteractor.CanBeSelected(cardId);
            investigatorCardsManager.AllCards[cardId].Activate(canBeSelected);
        }

        private void RefreshAllCardsVisibility()
        {
            foreach (ICardVisualizable cardView in investigatorCardsManager.CardsList)
            {
                bool canBeSelected = investigatorSelectorInteractor.CanBeSelected(cardView.Id);
                cardView.Activate(canBeSelected);
            }
        }
    }
}