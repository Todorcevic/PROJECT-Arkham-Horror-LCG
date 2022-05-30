using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardsButtonEventHandler : IInitializable, IDisposable
    {
        [Inject] private readonly MidPanelPresenter midPanelPresenter;
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;

        /*******************************************************************/
        void IInitializable.Initialize() => cardsButton.ClickAction += Clicked;
        void IDisposable.Dispose() => cardsButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked() => midPanelPresenter.SelectCardsPanel();
    }
}