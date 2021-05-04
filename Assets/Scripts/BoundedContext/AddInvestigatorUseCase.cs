using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.Adapter
{
    public class AddInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly ReadyButtonController readyButton;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter selectorInvestigator;

        /*******************************************************************/
        public void Add(string investigatorId)
        {
            UpdateModel(investigatorId);
            UpdateView(investigatorId);
        }

        private void UpdateModel(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            selector.Add(investigator);
        }

        private void UpdateView(string investigatorId)
        {
            selectorInvestigator.AddInvestigator(investigatorId);
            investigatorVisibility.RefreshInvestigatorsVisibility();
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
