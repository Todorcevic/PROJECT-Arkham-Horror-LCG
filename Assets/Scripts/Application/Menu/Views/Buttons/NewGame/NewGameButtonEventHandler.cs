using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class NewGameButtonEventHandler : IInitializable, IDisposable
    {
        [Inject(Id = "NewGameModal")] private readonly ModalPanelView newGameModal;
        [Inject(Id = "NewGameButton")] private readonly ButtonView newGameButton;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameButton.ClickAction += Clicked;
        void IDisposable.Dispose() => newGameButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => newGameModal.Activate(true);
    }
}
