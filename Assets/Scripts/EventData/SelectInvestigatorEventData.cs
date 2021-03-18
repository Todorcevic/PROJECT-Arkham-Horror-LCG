using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class SelectInvestigatorEventData : ISelectInvestigator, ISelectInvestigatorEvent
    {
        [Inject] private readonly Repository repository;
        public event Action<string> InvestigatorSelectedChanged;

        /*******************************************************************/
        public void SelectInvestigator(string investigatorId)
        {
            repository.CurrentInvestigatorSelected = investigatorId;
            InvestigatorSelectedChanged?.Invoke(investigatorId);
        }
    }
}
