using Arkham.Config;
using Zenject;
using Arkham.UseCases;

namespace Arkham.Views
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly StartGameUseCase startGame;
        [Inject] private readonly SelectScenarioUseCase scenarioEvent;
        [Inject(Id = "ModalNewGameYesButton")] private readonly ButtonView yesButton;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsManagerComponent mainPanelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCampaignPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.AddClickAction(Clicked);

        private void Clicked()
        {
            startGame.Init(StartGame.New);
            scenarioEvent.Reset();
            mainPanelsManager.SelectPanel(chooseCampaignPanel);
        }
    }
}
