using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ButtonsPresenter
    {
        [Inject] private readonly SelectorsRepository selectorRepository;
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;
        [Inject(Id = "RetireButton")] private readonly ButtonIconView retireButton;

        /*******************************************************************/
        public void AutoActivateReadyButton() => readyButton.Desactive(!selectorRepository.IsReady);

        public void AutoActivateContinueButton() => continueButton.Desactive(campaignRepository.CurrentScenario == null);

        public void AutoActivateRetireButton(Investigator investigator) => retireButton.Activate(investigator?.State == InvestigatorState.None && investigator!.IsPlaying);

        public void ExecuteCardsButton() => cardsButton.ExecuteClick();

        public void ExecuteInvestigatorsButton() => investigatorsButton.ExecuteClick();
    }
}
