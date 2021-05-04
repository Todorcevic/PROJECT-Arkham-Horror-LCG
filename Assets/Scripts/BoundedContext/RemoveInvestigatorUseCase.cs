using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.Adapter
{
    public class RemoveInvestigatorUseCase
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selector;
        [Inject] private readonly ReadyButtonController readyButton;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorRemove;

        /*******************************************************************/
        public void Remove(string investigatorId)
        {
            UpdateModel(investigatorId);
            UpdateView(investigatorId);
        }

        private void UpdateModel(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            selector.Remove(investigator);
        }

        private void UpdateView(string investigatorId)
        {
            investigatorVisibility.RefreshInvestigatorsVisibility();
            investigatorRemove.RemoveInvestigator(investigatorId);
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
