using Arkham.Config;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class ContinueButtonController : IInitializable
    {
        [Inject] private readonly StartGameUseCase startGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsManagerComponent panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => continueButton.AddClickAction(Clicked);

        /*******************************************************************/
        private void Clicked()
        {
            startGame.Init(StartGame.Continue);
            panelsManager.SelectPanel(chooseCardPanel);
        }
    }
}
