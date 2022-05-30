using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class NewGameModalEventHandler : IInitializable, IDisposable
    {
        [Inject] private readonly NewGameUseCase startGameUseCase;
        [Inject(Id = "NewGameModal")] private readonly ModalPanelView newGameModal;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameModal.YesButton.ClickAction += Clicked;
        void IDisposable.Dispose() => newGameModal.YesButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => startGameUseCase.StartNewGame();
    }
}
