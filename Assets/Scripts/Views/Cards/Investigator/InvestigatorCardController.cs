using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardController : IInvestigatorCardController
    {
        [Inject] private readonly InvestigatorSelectorEventDomain investigatorSelector;

        /*******************************************************************/
        public void Clicked(string investigatorId)
        {
            investigatorSelector.Add(investigatorId);
            investigatorSelector.Select(investigatorId);
        }
    }
}
