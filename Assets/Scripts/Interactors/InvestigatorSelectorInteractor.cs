using Arkham.Managers;
using Arkham.Presenters;
using Arkham.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Zenject;

namespace Arkham.Interactors
{
    public class InvestigatorSelectorInteractor : IInvestigatorSelectorInteractor
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        public event Action<string> InvestigatorSelectedChanged;
        public event Action<string> InvestigatorAdded;
        public event Action<string> InvestigatorRemoved;
        public string InvestigatorSelected { get; private set; }
        public string LeadInvestigator => investigatorSelectorRepository.InvestigatorsSelectedList.FirstOrDefault();
        public List<string> InvestigatorsSelectedList => investigatorSelectorRepository.InvestigatorsSelectedList;

        /*******************************************************************/
        public void SelectInvestigator(string investigatorId)
        {
            InvestigatorSelected = investigatorId;
            InvestigatorSelectedChanged?.Invoke(investigatorId);
        }

        public void AddInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Add(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
            SelectInvestigator(investigatorId);
        }

        public void RemoveInvestigator(string investigatorId)
        {
            investigatorSelectorRepository.InvestigatorsSelectedList.Remove(investigatorId);
            InvestigatorRemoved?.Invoke(investigatorId);
            SelectInvestigator(investigatorSelectorRepository.InvestigatorsSelectedList.FirstOrDefault());
        }
    }
}
