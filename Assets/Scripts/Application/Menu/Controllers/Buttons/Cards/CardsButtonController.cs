using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CardsButtonController : IInitializable, IDisposable
    {
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;
        [Inject(Id = "MidPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "CardsPanel")] private readonly PanelView cardsPanel;
        [Inject(Id = "CardsPanel")] private readonly RectTransform panelToScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect scroll;

        /*******************************************************************/
        void IInitializable.Initialize() => cardsButton.ClickAction += Clicked;

        void IDisposable.Dispose() => cardsButton.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked()
        {
            panelsManager.SelectPanel(cardsPanel);
            scroll.content = panelToScroll;
        }
    }
}
