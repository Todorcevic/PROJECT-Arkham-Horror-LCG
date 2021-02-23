using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Repositories;
using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Presenters
{
    public class InvestigatorCardPresenter : CardPresenter, IInvestigatorCardPresenter
    {
        [Inject] private readonly IInvestigatorSelectorInteractor selectorInteractor;
        protected override bool SelectionIsFull => selectorInteractor.InvestigatorsSelectedList.Count >= GameData.MAX_INVESTIGATORS;
        private bool SelectionIsNotFull => selectorInteractor.InvestigatorsSelectedList.Count == GameData.MAX_INVESTIGATORS - 1;
        public List<IInvestigatorCardView> InvestigatorCardsList => CardsList.OfType<IInvestigatorCardView>().ToList();

        /*******************************************************************/
        [Inject]
        public void InjectDependency(ICardsInvestigatorManager investigatorCardsManager)
        {
            cardsManager = investigatorCardsManager;
        }

        public override void Init()
        {
            selectorInteractor.InvestigatorAdded += ResolveAddVisibility;
            selectorInteractor.InvestigatorRemoved += ResolveRemoveVisibility;
            RefreshAllCardsVisibility();
        }

        private void ResolveAddVisibility(string investigatorId)
        {
            if (SelectionIsFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        private void ResolveRemoveVisibility(string investigatorId)
        {
            if (SelectionIsNotFull) RefreshAllCardsVisibility();
            else RefreshCardVisibility(investigatorId);
        }

        protected override int AmountCardsSelected(string cardId) =>
            selectorInteractor.InvestigatorsSelectedList.FindAll(i => i == cardId).Count;
    }
}
