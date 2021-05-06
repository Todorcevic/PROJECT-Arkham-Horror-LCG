using Zenject;
using Arkham.Application;

namespace Arkham.Application
{
    public class InvestigatorCardController : ICardController
    {
        [Inject] private readonly AddInvestigatorUseCase investigatorAddEvent;
        [Inject] private readonly SelectInvestigatorUseCase investigatorSelectEvent;

        /*******************************************************************/
        public void Clicked(string investigatorId)
        {
            investigatorAddEvent.Add(investigatorId);
            investigatorSelectEvent.Select(investigatorId);
        }
    }
}
