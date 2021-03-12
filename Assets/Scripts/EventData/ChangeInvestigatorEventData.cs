using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class ChangeInvestigatorEventData : IChangeInvestigator, IChangeInvestigatorEvent
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        public event Action<string, string> InvestigatorChanged;

        /*******************************************************************/
        public void Swap(int positionToSwap, string investigatorId)
        {
            int realPosition = investigatorSelectorRepository.InvestigatorsSelectedList.IndexOf(investigatorId);
            investigatorSelectorRepository.InvestigatorsSelectedList[realPosition] = investigatorSelectorRepository.InvestigatorsSelectedList[positionToSwap];
            investigatorSelectorRepository.InvestigatorsSelectedList[positionToSwap] = investigatorId;
            InvestigatorChanged?.Invoke(investigatorId, investigatorSelectorRepository.InvestigatorsSelectedList[realPosition]);
        }
    }
}
