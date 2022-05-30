using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ContinueButtonEventHandler : IInitializable, IDisposable
    {
        [Inject] private readonly StartGameUseCase startGame;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        void IInitializable.Initialize() => continueButton.ClickAction += Clicked;
        void IDisposable.Dispose() => continueButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => startGame.ContinueGame();
    }
}
