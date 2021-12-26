using Zenject;

namespace Arkham.Application.MainMenu
{
    public class NewGameButtonController : IInitializable
    {
        [Inject(Id = "NewGameButton")] private readonly ButtonView newGameButton;
        [Inject(Id = "NewGameModal")] private readonly PanelView newGameModal;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameButton.ClickAction += () => newGameModal.Activate(true);
    }
}
