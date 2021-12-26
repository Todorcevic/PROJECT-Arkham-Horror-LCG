using System.IO;
using Zenject;
using Arkham.Model;

namespace Arkham.Application.MainMenu
{
    public class ContinueButtonController : IInitializable
    {
        [Inject] private readonly GameFiles gameFiles;
        [Inject] private readonly StartGameUseCase startGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator mainPanelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView chooseCardPanel;

        private bool CanContinue => File.Exists(gameFiles.PlayerProgressFilePath);

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            continueButton.ClickAction += Clicked;
            continueButton.Desactive(!CanContinue);
        }

        /*******************************************************************/
        private void Clicked()
        {
            startGame.Init(StartGame.Continue);
            mainPanelsManager.SelectPanel(chooseCardPanel);
        }
    }
}
