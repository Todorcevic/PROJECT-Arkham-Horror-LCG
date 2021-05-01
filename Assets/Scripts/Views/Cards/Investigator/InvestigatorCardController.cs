using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardController : IInvestigatorCardController
    {
        [Inject] private readonly AddInvestigatorEventDomain investigatorAddEvent;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;

        /*******************************************************************/
        public void Clicked(string investigatorId)
        {
            investigatorAddEvent.Add(investigatorId);
            investigatorSelectEvent.Select(investigatorId);
        }
    }
}
