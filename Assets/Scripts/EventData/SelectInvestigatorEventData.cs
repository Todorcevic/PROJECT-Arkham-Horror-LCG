using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class SelectInvestigatorEventData : ISelectInvestigator, ISelectInvestigatorEvent
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        public event Action<string> InvestigatorSelectedChanged;

        /*******************************************************************/
        public void SelectInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.CurrentInvestigatorSelected = investigatorId;
            InvestigatorSelectedChanged?.Invoke(investigatorId);
        }
    }
}
