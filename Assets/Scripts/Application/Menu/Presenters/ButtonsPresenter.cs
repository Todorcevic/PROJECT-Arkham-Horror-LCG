using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ButtonsPresenter
    {
        [Inject] private readonly ApplicationValues applicationValues;
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly PlayerPrefService playerPrefs;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;
        [Inject(Id = "RetireButton")] private readonly ButtonIconView retireButton;
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;

        /*******************************************************************/
        public void AutoActivateReadyButton() => readyButton.Desactive(!selectorRepository.IsReady);
        public void AutoActivateRetireButton(Investigator investigator) => retireButton.Activate(investigator?.State == InvestigatorState.None && investigator!.IsPlaying);
        public void ExecuteCardsButton() => cardsButton.ExecuteClick();
        public void ExecuteInvestigatorsButton() => investigatorsButton.ExecuteClick();
        public void AutoActivateContinueButton() => continueButton.Desactive(!applicationValues.CanContinue);
        public void AutoActivateVisibilitySwitch() => visibilitySwitchView.SwitchAnimation(playerPrefs.LoadCardsVisibility());
    }
}
