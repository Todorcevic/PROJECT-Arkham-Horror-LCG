using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class MidPanelPresenter
    {
        [Inject(Id = "MidPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "InvestigatorsPanel")] private readonly PanelView investigatorsPanel;
        [Inject(Id = "CardsPanel")] private readonly PanelView cardsPanel;
        [Inject(Id = "InvestigatorsPanel")] private readonly RectTransform investigatorPanelToScroll;
        [Inject(Id = "CardsPanel")] private readonly RectTransform cardPanelToScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect scroll;

        /*******************************************************************/
        public void SelectInvestigatorsPanel()
        {
            panelsManager.SelectPanel(investigatorsPanel);
            scroll.content = investigatorPanelToScroll;
        }

        public void SelectCardsPanel()
        {
            panelsManager.SelectPanel(cardsPanel);
            scroll.content = cardPanelToScroll;
        }
    }
}
