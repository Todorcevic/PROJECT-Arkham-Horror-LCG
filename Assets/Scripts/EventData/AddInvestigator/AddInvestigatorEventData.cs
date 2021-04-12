using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class AddInvestigatorEventData : IAddInvestigator, IAddInvestigatorEvent
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        private event Action<string> InvestigatorAdded;

        /*******************************************************************/
        void IAddInvestigator.AddInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Add(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
        }

        void IAddInvestigatorEvent.AddAction(Action<string> action) => InvestigatorAdded += action;
    }
}
