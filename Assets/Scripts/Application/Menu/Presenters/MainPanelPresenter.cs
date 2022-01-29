using Zenject;

namespace Arkham.Application.MainMenu
{
    public class MainPanelPresenter
    {
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly InvestigatorsCardPresenter investigatorsCardPresenter;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;
        [Inject] private readonly CampaignPresenter campaignPresenter;
        [Inject] private readonly MidPanelPresenter midPanelPresenter;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator mainPanelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCampaignPanel;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView chooseCardPanel;
        [Inject(Id = "HomePanel")] private readonly PanelView homePanel;

        /*******************************************************************/
        public void ChooseCampaignPanel()
        {
            campaignPresenter.InitializeCampaigns();
            mainPanelsManager.SelectPanel(chooseCampaignPanel);
        }

        public void ChooseSelectionPanel()
        {
            UpdateSelectionPanel();
            mainPanelsManager.SelectPanel(chooseCardPanel);

            void UpdateSelectionPanel()
            {
                midPanelPresenter.SelectInvestigatorsPanel();
                investigatorSelector.InitializeSelectors();
                investigatorSelector.SetLeadSelector();
                investigatorsCardPresenter.InvestigatorStateResolve();
                investigatorsCardPresenter.RefreshInvestigatorsSelectability();
                investigatorsCardPresenter.RefreshInvestigatorsVisibility();
                deckCardPresenter.RefreshCardsSelectability();
                deckCardPresenter.RefreshCardsVisibility();
                deckCardPresenter.RefresQuantity();
                buttonsPresenter.AutoActivateReadyButton();
            }
        }

        public void ChooseHomePanel()
        {
            buttonsPresenter.AutoActivateContinueButton();
            mainPanelsManager.SelectPanel(homePanel);
        }
    }
}
