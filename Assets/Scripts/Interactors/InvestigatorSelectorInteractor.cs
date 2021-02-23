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
        public string InvestigatorFocused { get; set; }
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }

        /*******************************************************************/
        public void SelectInvestigator(string investigatorId)
        {
            InvestigatorFocused = investigatorId;
            InvestigatorSelectedChanged?.Invoke(investigatorId);
        }

        public void AddInvestigator(string investigatorId)
        {
            InvestigatorsSelectedList.Add(investigatorId);
            SelectInvestigator(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
        }

        public void RemoveInvestigator(string investigatorId)
        {
            InvestigatorsSelectedList.Remove(investigatorId);
            SelectInvestigator(InvestigatorsSelectedList.FirstOrDefault());
            InvestigatorRemoved?.Invoke(investigatorId);
        }
    }
}
