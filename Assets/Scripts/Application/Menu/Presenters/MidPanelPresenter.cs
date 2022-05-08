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

        [Inject(Id = "MidButtons")] private readonly ButtonsMediator midButtons;
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;
        [Inject(Id = "CardsButton")] private readonly ButtonView cardsButton;

        /*******************************************************************/
        public void SelectInvestigatorsPanel()
        {
            midButtons.SelectButton(investigatorsButton);
            panelsManager.SelectPanel(investigatorsPanel);
            scroll.content = investigatorPanelToScroll;
        }

        public void SelectCardsPanel()
        {
            midButtons.SelectButton(cardsButton);
            panelsManager.SelectPanel(cardsPanel);
            scroll.content = cardPanelToScroll;
        }
    }
}
