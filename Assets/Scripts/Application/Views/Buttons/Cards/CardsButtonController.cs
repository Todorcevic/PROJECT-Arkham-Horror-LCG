using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application
{
    public class CardsButtonController : IInitializable
    {
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;
        [Inject(Id = "MidPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "CardsPanel")] private readonly PanelView cardsPanel;
        [Inject(Id = "CardsPanel")] private readonly RectTransform panelToScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect scroll;

        /*******************************************************************/
        void IInitializable.Initialize() => cardsButton.AddClickAction(Clicked);

        /*******************************************************************/
        private void Clicked()
        {
            panelsManager.SelectPanel(cardsPanel);
            scroll.content = panelToScroll;
        }
    }
}
