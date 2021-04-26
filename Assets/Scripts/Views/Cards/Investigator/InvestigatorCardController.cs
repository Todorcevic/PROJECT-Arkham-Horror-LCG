using Arkham.EventData;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardController : IInvestigatorCardController
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;

        /*******************************************************************/
        public void Clicked(string investigatorId)
        {
            investigatorSelectorRepository.Add(investigatorId);
            investigatorSelectorRepository.SelectCurrent(investigatorId);
        }
    }
}
