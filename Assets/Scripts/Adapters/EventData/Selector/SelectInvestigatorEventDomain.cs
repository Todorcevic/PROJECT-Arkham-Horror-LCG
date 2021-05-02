using Arkham.Model;
using System;
using Zenject;

namespace Arkham.Adapter
{
    public class SelectInvestigatorEventDomain
    {
        private event Action<string> InvestigatorSelected;
        [Inject] private readonly Selector selectorRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;

        /*******************************************************************/
        public void Select(string investigatorId)
        {
            Investigator investigator = investigatorRepository.Get(investigatorId);
            Select(investigator);
        }

        public void SelectLead() => Select(selectorRepository.Lead);

        public void SelectCurrentOrLead() => Select(selectorRepository.InvestigatorSelected ?? selectorRepository.Lead);

        private void Select(Investigator investigator)
        {
            selectorRepository.InvestigatorSelected = investigator;
            InvestigatorSelected?.Invoke(investigator?.Id);
        }

        public void Subscribe(Action<string> action) => InvestigatorSelected += action;
    }
}
