using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class NewGameButtonController : IInitializable, IDisposable
    {
        [Inject] private readonly PanelPresenter panelPresenter;
        [Inject(Id = "NewGameButton")] private readonly ButtonView newGameButton;

        /*******************************************************************/
        void IInitializable.Initialize() => newGameButton.ClickAction += Clicked;

        void IDisposable.Dispose() => newGameButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => panelPresenter.NewGameModal(true);
    }
}
