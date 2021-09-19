using Zenject;

namespace Arkham.Application
{
    public class RetireController : ButtonIcon
    {
        [Inject] private readonly RetireInvestigatorUseCase retireInvestigatorUseCase;

        /*******************************************************************/
        private void Start()
        {
            ClickAction += retireInvestigatorUseCase.Retire;
        }
    }
}