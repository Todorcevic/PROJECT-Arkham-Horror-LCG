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
    public class InvestigatorSelectorInteractor : IInvestigatorSelectorInteractor, ISelectorRepository
    {
        public event Action<string> InvestigatorSelectedChanged;
        public event Action<string> InvestigatorAdded;
        public event Action<string> InvestigatorRemoved;
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }
        public string InvestigatorFocused { get; private set; }
        public string LeadInvestigator => InvestigatorsSelectedList.FirstOrDefault();

        /*******************************************************************/
        public void SelectInvestigator(string investigatorId)
        {
            InvestigatorFocused = investigatorId;
            InvestigatorSelectedChanged?.Invoke(investigatorId);
        }

        public void AddInvestigator(string investigatorId)
        {
            InvestigatorsSelectedList.Add(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
            SelectInvestigator(investigatorId);
        }

        public void RemoveInvestigator(string investigatorId)
        {
            InvestigatorsSelectedList.Remove(investigatorId);
            InvestigatorRemoved?.Invoke(investigatorId);
            SelectInvestigator(InvestigatorsSelectedList.FirstOrDefault());
        }
    }
}
