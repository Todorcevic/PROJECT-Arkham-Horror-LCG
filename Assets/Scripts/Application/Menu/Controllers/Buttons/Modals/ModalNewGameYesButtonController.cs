using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ModalNewGameYesButtonController : IInitializable
    {
        [Inject] private readonly StartGameUseCase startGameUseCase;
        [Inject(Id = "ModalNewGameYesButton")] private readonly ButtonView yesButton;

        /*******************************************************************/
        void IInitializable.Initialize() => yesButton.ClickAction += Clicked;

        private void Clicked() => startGameUseCase.StartNewGame();
    }
}
