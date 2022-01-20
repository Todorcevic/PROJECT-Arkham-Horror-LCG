using Zenject;

namespace Arkham.Application.MainMenu
{
    public class NewGameButtonController : IInitializable
    {
        [Inject] private readonly PanelPresenter panelPresenter;
        [Inject(Id = "NewGameButton")] private readonly ButtonView newGameButton;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameButton.ClickAction += () => panelPresenter.NewGameModal(true);
    }
}
