using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class AddInvestigatorEventData : IAddInvestigator, IAddInvestigatorEvent
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        public event Action<string> InvestigatorAdded;

        /*******************************************************************/
        public void AddInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Add(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
        }
    }
}
