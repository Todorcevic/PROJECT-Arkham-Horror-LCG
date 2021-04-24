using Arkham.EventData;
using Zenject;

namespace Arkham.View
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly IStartGame startGame;
        [Inject] private readonly IChangeScenario changeScenario;
        [Inject(Id = "ModalNewGameYesButton")] private readonly ButtonView yesButton;
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.AddClickAction(Clicked);

        private void Clicked()
        {
            startGame.NewGame();
            changeScenario.SelectingScenario(null);
            panelsManager.SelectPanel(chooseCardPanel);
        }
    }
}
