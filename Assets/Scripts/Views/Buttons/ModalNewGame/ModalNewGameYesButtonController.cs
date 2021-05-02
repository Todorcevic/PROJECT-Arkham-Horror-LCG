using Arkham.Config;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly StartGameUseCase startGame;
        [Inject] private readonly ScenarioEventDomain scenarioEvent;
        [Inject(Id = "ModalNewGameYesButton")] private readonly ButtonView yesButton;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsManagerComponent panelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.AddClickAction(Clicked);

        private void Clicked()
        {
            startGame.Init(StartGame.New);
            scenarioEvent.Reset();
            panelsManager.SelectPanel(chooseCardPanel);
        }
    }
}
