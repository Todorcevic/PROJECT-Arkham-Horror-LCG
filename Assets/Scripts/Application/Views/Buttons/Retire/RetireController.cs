using Zenject;

namespace Arkham.Application
{
    public class RetireController : IInitializable
    {
        [Inject] private readonly RetireInvestigatorUseCase retireInvestigatorUseCase;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "Retire Button")] private readonly ButtonIcon retireButton;

        /*******************************************************************/
        public void Initialize()
        {
            retireButton.ClickAction += () => retireInvestigatorUseCase.Retire(investigatorSelectorManager.CurrentInvestigatorId);
        }
    }
}