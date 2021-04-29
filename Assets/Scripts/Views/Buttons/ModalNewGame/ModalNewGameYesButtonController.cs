using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly StartGameEventDomain startGame;
        [Inject] private readonly CampaignChangeEventDomain currentScenario;
        [Inject(Id = "ModalNewGameYesButton")] private readonly ButtonView yesButton;
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.AddClickAction(Clicked);

        private void Clicked()
        {
            startGame.Init(StartGame.New);
            currentScenario.Select(null);
            panelsManager.SelectPanel(chooseCardPanel);
        }
    }
}
