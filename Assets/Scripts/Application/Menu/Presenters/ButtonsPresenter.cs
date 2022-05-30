using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ButtonsPresenter
    {
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;
        [Inject(Id = "RetireButton")] private readonly ButtonIconView retireButton;

        /*******************************************************************/
        public void AutoActivateReadyButton() => readyButton.Desactive(!selectorRepository.IsReady);
        public void AutoActivateRetireButton(Investigator investigator) => retireButton.Activate(investigator?.State == InvestigatorState.None && investigator!.IsPlaying);
        public void AutoActivateContinueButton() => continueButton.Desactive(!applicationValues.CanContinue);
    }
}
