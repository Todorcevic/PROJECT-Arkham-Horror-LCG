using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class RemoveInvestigatorEventData : IRemoveInvestigator, IRemoveInvestigatorEvent
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        public event Action<string> InvestigatorRemoved;

        /*******************************************************************/
        public void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Remove(investigatorId);
            InvestigatorRemoved?.Invoke(investigatorId);
        }
    }
}
