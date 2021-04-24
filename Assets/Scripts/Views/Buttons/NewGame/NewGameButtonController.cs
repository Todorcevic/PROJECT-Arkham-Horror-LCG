using Zenject;

namespace Arkham.Views
{
    public class NewGameButtonController : IInitializable
    {
        [Inject(Id = "NewGameButton")] private readonly ButtonView newGameButton;
        [Inject(Id = "NewGameModal")] private readonly PanelView newGameModal;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameButton.AddClickAction(() => newGameModal.Activate(true));
    }
}
