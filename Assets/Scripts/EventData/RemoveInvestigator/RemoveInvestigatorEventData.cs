using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class RemoveInvestigatorEventData : IRemoveInvestigator, IRemoveInvestigatorEvent
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        private event Action<string> InvestigatorRemoved;

        /*******************************************************************/
        void IRemoveInvestigator.Removing(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Remove(investigatorId);
            InvestigatorRemoved?.Invoke(investigatorId);
        }

        void IRemoveInvestigatorEvent.AddAction(Action<string> action) => InvestigatorRemoved += action;
    }
}
