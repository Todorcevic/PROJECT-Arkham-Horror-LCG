using System;
using Zenject;

namespace Arkham.Model
{
    public class InvestigatorSelectorEventDomain
    {
        [Inject] private readonly InvestigatorSelectorRepository selectorRepository;

        private event Action<string> InvestigatorSelected;
        private event Action<string, string> InvestigatorChanged;
        private event Action<string> InvestigatorAdded;
        private event Action<string> InvestigatorRemoved;

        public void Add(string investigatorId)
        {
            selectorRepository.InvestigatorsSelectedList.Add(investigatorId);
            InvestigatorAdded?.Invoke(investigatorId);
        }

        public void Remove(string investigatorId)
        {
            selectorRepository.InvestigatorsSelectedList.Remove(investigatorId);
            InvestigatorRemoved?.Invoke(investigatorId);
        }

        public void Select(string investigatorId)
        {
            selectorRepository.CurrentInvestigatorSelected = investigatorId;
            InvestigatorSelected?.Invoke(investigatorId);
        }

        public void SelectLead() => Select(selectorRepository.Lead);

        public void SelectCurrentOrLead() => Select(selectorRepository.CurrentInvestigatorSelected
                ?? selectorRepository.Lead);

        public void Swap(int positionToSwap, string investigatorId)
        {
            int realPosition = selectorRepository.InvestigatorsSelectedList.IndexOf(investigatorId);
            selectorRepository.InvestigatorsSelectedList[realPosition] = selectorRepository.InvestigatorsSelectedList[positionToSwap];
            selectorRepository.InvestigatorsSelectedList[positionToSwap] = investigatorId;
            InvestigatorChanged?.Invoke(investigatorId, selectorRepository.InvestigatorsSelectedList[realPosition]);
        }

        public void Select(Action<string> action) => InvestigatorSelected += action;

        public void Change(Action<string, string> action) => InvestigatorChanged += action;

        public void Add(Action<string> action) => InvestigatorAdded += action;

        public void Remove(Action<string> action) => InvestigatorRemoved += action;
    }
}
