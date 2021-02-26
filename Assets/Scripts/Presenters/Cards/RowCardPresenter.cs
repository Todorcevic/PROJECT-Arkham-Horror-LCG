using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Models;
using Zenject;

namespace Arkham.Presenters
{
    public class RowCardPresenter : CardPresenter, IRowCardPresenter
    {
        [Inject] private readonly IDeckBuilderInteractor investigatorsInteractor;
        protected override bool SelectionIsFull => false;

        /*******************************************************************/
        [Inject]
        public void InjectDependency(IRowCardsManager rowCardsManager)
        {
            cardsManager = rowCardsManager;
        }

        public override void Init()
        {
            investigatorsInteractor.DeckCardAdded += ResolveAddVisibility;
            investigatorsInteractor.DeckCardRemoved += ResolveRemoveVisibility;
            //selectorInteractor.InvestigatorAdded += ResolveAddVisibility;
            //selectorInteractor.InvestigatorRemoved += ResolveRemoveVisibility;
            //RefreshAllCardsVisibility();
        }

        private void ResolveAddVisibility(string cardId)
        {
            cardsManager.AllCards[cardId].Show(true);
            //if (SelectionIsFull) RefreshAllCardsVisibility();
            //else RefreshCardVisibility(investigatorId);
        }

        private void ResolveRemoveVisibility(string cardId)
        {
            cardsManager.AllCards[cardId].Show(false);
            //if (SelectionIsNotFull) RefreshAllCardsVisibility();
            //else RefreshCardVisibility(investigatorId);
        }

        protected override int AmountCardsSelected(string cardId)
        {
            throw new System.NotImplementedException();
        }
    }
}
