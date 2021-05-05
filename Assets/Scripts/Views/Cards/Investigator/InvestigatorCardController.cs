using Zenject;
using Arkham.UseCases;

namespace Arkham.Views
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
