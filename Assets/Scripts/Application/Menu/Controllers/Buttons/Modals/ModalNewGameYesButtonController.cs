using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly StartGameUseCase startGame;
        [Inject] private readonly SelectScenarioUseCase selectScenarioUseCase;
        [Inject(Id = "ModalNewGameYesButton")] private readonly ButtonView yesButton;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator mainPanelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCampaignPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.ClickAction += Clicked;

        private void Clicked()
        {
            startGame.Init(StartGame.New);
            selectScenarioUseCase.Reset();
            mainPanelsManager.SelectPanel(chooseCampaignPanel);
        }
    }
}
