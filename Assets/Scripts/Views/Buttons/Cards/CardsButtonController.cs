using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class CardsButtonController : IInitializable
    {
        [Inject(Id = "CardsButton")] private readonly IClickable investigatorsButton;
        [Inject(Id = "MidPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "CardsPanel")] private readonly IPanelView cardsPanel;
        [Inject(Id = "CardsPanel")] private readonly RectTransform panelToScroll;
        [Inject] private readonly ScrollRect scroll;

        /*******************************************************************/
        void IInitializable.Initialize() => investigatorsButton.AddAction(Clicked);

        /*******************************************************************/
        private void Clicked()
        {
            panelsManager.SelectPanel(cardsPanel);
            scroll.content = panelToScroll;
        }
    }
}
