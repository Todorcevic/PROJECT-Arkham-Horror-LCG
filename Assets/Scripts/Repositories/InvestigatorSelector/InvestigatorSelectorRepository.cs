using Arkham.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Arkham.Repositories
{
    [DataContract]
    public class InvestigatorSelectorRepository : IInvestigatorSelectorLoader, IInvestigatorSelectorRepository,
        IInvestigatorSelectedEvent, IInvestigatorChangedEvent,
        IInvestigatorAddedEvent, IInvestigatorRemovedEvent, IInvestigatorSelectorInfo
    {
        private event Action<string> InvestigatorSelected;
        private event Action<string, string> InvestigatorChanged;
        private event Action<string> InvestigatorAdded;
        private event Action<string> InvestigatorRemoved;

        public string CurrentInvestigatorSelected { get; set; }
        public string Lead => InvestigatorsSelectedList.FirstOrDefault();
        public int AmontInvestigatorsSelected => InvestigatorsSelectedList.Count;
        public bool IsSelectionFull => AmontInvestigatorsSelected >= GameConfig.MAX_INVESTIGATORS;
        [DataMember] public List<string> InvestigatorsSelectedList { get; set; }
        public IEnumerable<string> AllInvestigatorsSelected => InvestigatorsSelectedList;

        /*******************************************************************/
        public void Add(string investigatorId)
        {
            InvestigatorsSelectedList.Add(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
        }

        public void Remove(string investigatorId)
        {
            InvestigatorsSelectedList.Remove(investigatorId);
            InvestigatorRemoved?.Invoke(investigatorId);
        }

        public void SelectCurrent(string investigatorId)
        {
            CurrentInvestigatorSelected = investigatorId;
            InvestigatorSelected?.Invoke(investigatorId);
        }

        public void SelectLead() => SelectCurrent(Lead);

        public void SelectCurrentOrLead() => SelectCurrent(CurrentInvestigatorSelected
                ?? Lead);

        public void Swap(int positionToSwap, string investigatorId)
        {
            int realPosition = InvestigatorsSelectedList.IndexOf(investigatorId);
            InvestigatorsSelectedList[realPosition] = InvestigatorsSelectedList[positionToSwap];
            InvestigatorsSelectedList[positionToSwap] = investigatorId;
            InvestigatorChanged?.Invoke(investigatorId, InvestigatorsSelectedList[realPosition]);
        }

        void IInvestigatorSelectedEvent.Subscribe(Action<string> action) => InvestigatorSelected += action;

        void IInvestigatorChangedEvent.Subscribe(Action<string, string> action) => InvestigatorChanged += action;

        void IInvestigatorAddedEvent.Subscribe(Action<string> action) => InvestigatorAdded += action;

        void IInvestigatorRemovedEvent.Subscribe(Action<string> action) => InvestigatorRemoved += action;

        public bool Contains(string investigatorId) => InvestigatorsSelectedList.Contains(investigatorId);

        public int AmountSelectedOfThisInvestigator(string investigatorId) =>
            InvestigatorsSelectedList.FindAll(i => i == investigatorId).Count;
    }
}
