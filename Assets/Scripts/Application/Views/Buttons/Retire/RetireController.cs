using Zenject;

namespace Arkham.Application
{
    public class RetireController : ButtonIcon
    {
        [Inject] private readonly RetireInvestigatorUseCase retireInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;

        /*******************************************************************/
        private void Start()
        {
            ClickAction += () => retireInvestigatorUseCase.Retire(investigatorSelectorManager.CurrentInvestigatorId);
        }
    }
}