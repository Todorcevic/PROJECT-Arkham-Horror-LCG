using Zenject;

namespace Arkham.Application.MainMenu
{
    public class PanelPresenter
    {
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly InvestigatorsCardPresenter investigatorsCard;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;
        [Inject] private readonly CampaignPresenter campaignPresenter;
        [Inject(Id = "NewGameModal")] private readonly PanelView newGameModal;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator mainPanelsManager;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCampaignPanel;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView chooseCardPanel;
        [Inject(Id = "HomePanel")] private readonly PanelView homePanel;

        /*******************************************************************/
        public void NewGameModal(bool isOpen) => newGameModal.Activate(isOpen);

        public void ChooseCampaignPanel()
        {
            campaignPresenter.InitializeCampaigns();
            mainPanelsManager.SelectPanel(chooseCampaignPanel);
        }

        public void ChooseCardPanel()
        {
            UpdateCardPanel();
            mainPanelsManager.SelectPanel(chooseCardPanel);

            void UpdateCardPanel()
            {
                buttonsPresenter.ExecuteInvestigatorsButton();
                investigatorSelector.InitializeSelectors();
                investigatorSelector.SetLeadSelector();
                investigatorsCard.InvestigatorStateResolve();
                investigatorsCard.RefreshInvestigatorsSelectability();
                investigatorsCard.RefreshInvestigatorsVisibility();
                deckCardPresenter.RefresQuantity();
                buttonsPresenter.AutoActivateVisibilitySwitch();
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
