using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartGameUseCase
    {
        [Inject] private readonly DataMapperService dataPersistence;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly InvestigatorsCardPresenter investigatorsCard;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CampaignsManager campaignsManager;
        [Inject] private readonly CampaignsRepository campaignsRepository;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;

        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator mainPanelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView chooseCardPanel;
        [Inject(Id = "ChooseCampaignPanel")] private readonly PanelView chooseCampaignPanel;

        /*******************************************************************/
        public void Init(StartGame gameType)
        {
            UpdateApplication(gameType);
            UpdateView(gameType);
        }

        private void UpdateApplication(StartGame gameType) => dataPersistence.LoadProgress(gameType);

        private void UpdateView(StartGame gameType)
        {
            buttonsPresenter.ExecuteInvestigatorsButton();
            investigatorSelector.InitializeSelectors();
            investigatorSelector.SetLeadSelector();

            if (gameType == StartGame.New || campaignsRepository.CurrentScenario == null)
            {
                campaignsManager.InitializeCampaigns();
                mainPanelsManager.SelectPanel(chooseCampaignPanel);
            }
            else
            {
                mainPanelsManager.SelectPanel(chooseCardPanel);
            }

            investigatorsCard.InvestigatorStateResolve();
            investigatorsCard.RefreshInvestigatorsSelectability();
            investigatorsCard.RefreshInvestigatorsVisibility();
            deckCardPresenter.RefresQuantity();
            buttonsPresenter.AutoActivateReadyButton();
        }
    }
}

