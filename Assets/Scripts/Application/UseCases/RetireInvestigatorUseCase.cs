using Arkham.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Arkham.Application
{
    public class RetireInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly InvestigatorsCardPresenter investigatorCardsPresenter;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly RemoveInvestigatorUseCase removeInvestigatorUseCase;

        /*******************************************************************/
        public void Retire(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            removeInvestigatorUseCase.Remove(investigatorId);
            UpdateModel(investigator);
            UpdateView(investigator);
        }

        private void UpdateModel(Investigator investigator)
        {
            investigator.Retire();
        }

        private void UpdateView(Investigator investigator)
        {
            investigatorCardsPresenter.InvestigatorStateResolve();
            investigatorCardsPresenter.RefreshInvestigatorsVisibility();
            investigatorCardsPresenter.RefreshInvestigatorsSelectability();
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.RefresQuantity();
        }
    }
}
