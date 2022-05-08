using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ContinueButtonController : IInitializable, IDisposable
    {
        [Inject] private readonly ContinueGameUseCase continueGameUseCase;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        void IInitializable.Initialize() => continueButton.ClickAction += Clicked;
        void IDisposable.Dispose() => continueButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => continueGameUseCase.ContinueGame();
    }
}
