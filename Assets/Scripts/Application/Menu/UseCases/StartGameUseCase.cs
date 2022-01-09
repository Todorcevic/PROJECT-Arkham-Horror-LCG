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
        [Inject] private readonly ButtonsPresenter buttonsPresenter;

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
            if (gameType == StartGame.New) campaignsManager.InitializeCampaigns();
            investigatorsCard.InvestigatorStateResolve();
            investigatorsCard.RefreshInvestigatorsSelectability();
            investigatorsCard.RefreshInvestigatorsVisibility();
            deckCardPresenter.RefresQuantity();
            buttonsPresenter.AutoActivateReadyButton();
        }
    }
}

