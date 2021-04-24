using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorInitPresenter : IInitializable
    {
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IAddInvestigatorPresenter selectorAdd;
        [Inject] private readonly IInvestigatorLeadPresenter selectorLead;

        /*******************************************************************/
        public void Initialize() => startGameEvent.AddAction(InitializeSelectors);

        /*******************************************************************/
        private void InitializeSelectors()
        {
            investigatorSelectorsManager.ResetSelectors();
            AddAllInvestigators();
            SelectLeadInvestigator();
        }

        private void AddAllInvestigators() =>
            investigatorSelectorRepository.InvestigatorsSelectedList.ForEach(i => selectorAdd.InitInvestigator(i));

        private void SelectLeadInvestigator()
        {
            selectorLead.SetLeadSelector();
            selectInvestigator.Selecting(investigatorSelectorRepository.CurrentInvestigatorSelected
                ?? investigatorSelectorInteractor.LeadInvestigator);
        }
    }
}
