using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ContinueButtonController : IInitializable
    {
        [Inject] private readonly StartGameUseCase startGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        void IInitializable.Initialize() => continueButton.ClickAction += Clicked;

        /*******************************************************************/
        private void Clicked() => startGame.ContinueGame();
    }
}
