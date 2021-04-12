using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class ChangeInvestigatorEventData : IChangeInvestigator, IChangeInvestigatorEvent
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        private event Action<string, string> InvestigatorChanged;

        /*******************************************************************/
        void IChangeInvestigator.Swap(int positionToSwap, string investigatorId)
        {
            int realPosition = investigatorSelectorRepository.InvestigatorsSelectedList.IndexOf(investigatorId);
            investigatorSelectorRepository.InvestigatorsSelectedList[realPosition] = investigatorSelectorRepository.InvestigatorsSelectedList[positionToSwap];
            investigatorSelectorRepository.InvestigatorsSelectedList[positionToSwap] = investigatorId;
            InvestigatorChanged?.Invoke(investigatorId, investigatorSelectorRepository.InvestigatorsSelectedList[realPosition]);
        }

        void IChangeInvestigatorEvent.AddAction(Action<string, string> action) => InvestigatorChanged += action;
    }
}
