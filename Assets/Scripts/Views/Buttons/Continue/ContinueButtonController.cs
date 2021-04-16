using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class ContinueButtonController : IInitializable
    {
        [Inject] private readonly IStartGame startGame;
        [Inject(Id = "ContinueButton")] private readonly IClickable continueButton;
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView chooseCardPanel;

        /*******************************************************************/
        void IInitializable.Initialize() => continueButton.AddAction(Clicked);

        /*******************************************************************/

        private void Clicked()
        {
            startGame.ContinueGame();
            panelsManager.SelectPanel(chooseCardPanel);
        }
    }
}
