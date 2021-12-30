using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class AddInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorsRepository investigatorRepository;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly SelectInvestigatorUseCase selectInvestigatorUseCase;
        [Inject] private readonly CardShowerPresenter multiAnimator;

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
            multiAnimator.AddInvestigator(selector, investigatorId);
            investigatorSelector.SetLeadSelector();
            selectInvestigatorUseCase.Select(investigatorId);
            investigatorVisibility.RefreshInvestigatorsSelectability();
            multiAnimator.ReshowCardInvestigator(investigatorId);
            readyButton.AutoActivate();
        }
    }
}
