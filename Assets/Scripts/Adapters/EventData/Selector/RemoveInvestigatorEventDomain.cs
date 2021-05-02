using Arkham.Model;
using System;
using Zenject;

namespace Arkham.Adapter
{
    public class RemoveInvestigatorEventDomain
    {
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;
        private event Action<string> InvestigatorRemoved;

        /*******************************************************************/
        public void Remove(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            selectorRepository.Remove(investigator);
            InvestigatorRemoved?.Invoke(investigatorId);
        }

        public void Subscribe(Action<string> action) => InvestigatorRemoved += action;
    }
}
