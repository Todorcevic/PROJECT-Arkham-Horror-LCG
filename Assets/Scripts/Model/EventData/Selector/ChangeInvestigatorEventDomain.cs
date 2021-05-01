using System;
using Zenject;

namespace Arkham.Model
{
    public class ChangeInvestigatorEventDomain
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;
        private event Action<string, string> InvestigatorChanged;

        /*******************************************************************/
        public void Swap(int positionToSwap, string investigatorId)
        {
            Investigator investigator = selectorRepository.Swap(positionToSwap, investigatorRepository.Get(investigatorId));
            InvestigatorChanged?.Invoke(investigatorId, investigator.Id);
        }

        public void Subscribe(Action<string, string> action) => InvestigatorChanged += action;
    }
}
