using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class RetireInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly InvestigatorsCardPresenter investigatorCardsPresenter;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly RemoveInvestigatorUseCase removeInvestigatorUseCase;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;

        /*******************************************************************/
        public void Retire(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            removeInvestigatorUseCase.Remove(investigatorId);
            UpdateModel(investigator);
            UpdateView();
        }

        private void UpdateModel(Investigator investigator) => investigator.Retire();

        private void UpdateView()
        {
            investigatorCardsPresenter.InvestigatorStateResolve();
            investigatorCardsPresenter.RefreshInvestigatorsVisibility();
            investigatorCardsPresenter.RefreshInvestigatorsSelectability();
            deckCardPresenter.RefreshCardsSelectability();
            deckCardPresenter.RefresQuantity();
            selectInvestigatorUseCase.SelectLead();
        }
    }
}
