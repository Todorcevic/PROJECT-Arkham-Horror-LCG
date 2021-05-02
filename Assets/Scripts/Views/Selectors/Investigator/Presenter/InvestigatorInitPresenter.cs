using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class InvestigatorInitPresenter : IInitializable
    {
        [Inject] private readonly StartGameEventDomain startGameEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorsManager;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly IAddInvestigatorPresenter selectorAdd;
        [Inject] private readonly IInvestigatorLeadPresenter selectorLead;

        /*******************************************************************/
        public void Initialize() => startGameEvent.Subscribe((_) => InitializeSelectors());

        /*******************************************************************/
        private void InitializeSelectors()
        {
            investigatorSelectorsManager.ResetSelectors();
            AddAllInvestigators();
            SelectLeadInvestigator();
        }

        private void AddAllInvestigators()
        {
            foreach (string investigatorId in selectorRepository.Ids)
                selectorAdd.InitInvestigator(investigatorId);
        }

        private void SelectLeadInvestigator()
        {
            selectorLead.SetLeadSelector();
            investigatorSelectEvent.SelectCurrentOrLead();
        }
    }
}
