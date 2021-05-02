using Arkham.Model;
using System;
using Zenject;

namespace Arkham.Adapter
{
    public class AddInvestigatorEventDomain
    {
        private event Action<string> InvestigatorAdded;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly Selector selectorRepository;

        /*******************************************************************/
        public void Add(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            selectorRepository.Add(investigator);
            InvestigatorAdded?.Invoke(investigatorId);
        }

        public void Subscribe(Action<string> action) => InvestigatorAdded += action;
    }
}
