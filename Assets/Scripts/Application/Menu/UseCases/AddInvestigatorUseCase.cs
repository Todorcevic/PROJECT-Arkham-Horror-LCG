using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class AddInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly CardShowerPresenter cardShoerPresenter;

        /*******************************************************************/
        public void Add(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            UpdateModel(investigator);
            UpdateView(investigatorId);
        }

        private void UpdateModel(Investigator investigator) => selectorRepository.Add(investigator);

        private void UpdateView(string investigatorId)
        {
            InvestigatorSelectorView selector = investigatorSelector.AddInvestigatorToSelector(investigatorId);
            cardShoerPresenter.AddInvestigator(selector, investigatorId);
            investigatorSelector.SetLeadSelector();
            selectInvestigatorUseCase.Select(investigatorId);
            investigatorVisibility.RefreshInvestigatorsSelectability();
            cardShoerPresenter.ReshowCardInvestigator(investigatorId);
            buttonsPresenter.AutoActivateReadyButton();
        }
    }
}
