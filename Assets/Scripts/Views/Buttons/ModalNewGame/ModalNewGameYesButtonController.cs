using Arkham.EventData;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly IStartGame startGame;
        [Inject] private readonly ICampaignRepository changeScenario;
        [Inject(Id = "ModalNewGameYesButton")] private readonly ButtonView yesButton;
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.AddClickAction(Clicked);

        private void Clicked()
        {
            startGame.NewGame();
            changeScenario.SelectScenario(null);
            panelsManager.SelectPanel(chooseCardPanel);
        }
    }
}
