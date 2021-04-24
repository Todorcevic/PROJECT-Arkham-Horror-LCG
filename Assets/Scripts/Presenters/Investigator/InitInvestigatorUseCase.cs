using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InitInvestigatorUseCase : IInitializable
    {
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ISelectInvestigator selectInvestigator;
        [Inject] private readonly IAddInvestigatorUseCase selectorAdd;

        /*******************************************************************/
        public void Initialize() => startGameEvent.AddAction(InitializeSelectors);

        /*******************************************************************/
        private void InitializeSelectors()
        {
            CleanAllSelectors();
            AddAllInvestigators();
            SelectLeadInvestigator();
        }

        private void CleanAllSelectors() => investigatorSelectorsManager.EmptyAllSelectors();

        private void AddAllInvestigators() =>
           investigatorSelectorRepository.InvestigatorsSelectedList.ForEach(i => selectorAdd.AddInvestigator(i));

        private void SelectLeadInvestigator() =>
           selectInvestigator.Selecting(investigatorSelectorInteractor.LeadInvestigator);
    }
}
