using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class CardsButtonController : IInitializable
    {
        [Inject(Id = "CardsButton")] private readonly ButtonView investigatorsButton;
        [Inject(Id = "MidPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "CardsPanel")] private readonly PanelView cardsPanel;
        [Inject(Id = "CardsPanel")] private readonly RectTransform panelToScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect scroll;

        /*******************************************************************/
        void IInitializable.Initialize() => investigatorsButton.AddClickAction(Clicked);

        /*******************************************************************/
        private void Clicked()
        {
            panelsManager.SelectPanel(cardsPanel);
            scroll.content = panelToScroll;
        }
    }
}
