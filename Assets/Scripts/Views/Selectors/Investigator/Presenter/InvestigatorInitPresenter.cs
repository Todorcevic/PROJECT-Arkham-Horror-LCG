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
        [Inject] private readonly IInvestigatorSelectorInfo investigatorSelectorInfo;
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
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

        private void AddAllInvestigators()
        {
            foreach (string investigatorId in investigatorSelectorInfo.AllInvestigatorsSelected)
                selectorAdd.InitInvestigator(investigatorId);
        }

        private void SelectLeadInvestigator()
        {
            selectorLead.SetLeadSelector();
            investigatorSelectorRepository.SelectCurrentOrLead();
        }
    }
}
