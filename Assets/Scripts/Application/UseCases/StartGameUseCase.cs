using Arkham.Application;
using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class StartGameUseCase
    {
        [Inject] private readonly DataContext dataPersistence;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly InvestigatorsCardPresenter investigatorsCard;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CampaignsManager campaignsManager;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject(Id = "InvestigatorsButton")] private readonly ButtonView investigatorsButton;

        /*******************************************************************/
        public void Init(StartGame gameType)
        {
            UpdateModel(gameType);
            UpdateView(gameType);
        }

        private void UpdateModel(StartGame gameType) => dataPersistence.LoadProgress(gameType);

        private void UpdateView(StartGame gameType)
        {
            investigatorsButton.ExecuteClick();
            investigatorSelector.InitializeSelectors();
            investigatorSelector.SetLeadSelector();
            if (gameType == StartGame.New) campaignsManager.InitializeCampaigns();
            investigatorsCard.InvestigatorStateResolve();
            investigatorsCard.RefreshInvestigatorsSelectability();
            investigatorsCard.RefreshInvestigatorsVisibility();
            deckCardPresenter.RefresQuantity();
            readyButton.AutoActivate();
        }
    }
}

