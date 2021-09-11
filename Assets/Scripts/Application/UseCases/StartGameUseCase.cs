using Arkham.Config;
using Arkham.Services;
using Zenject;

namespace Arkham.Application
{
    public class StartGameUseCase
    {
        [Inject] private readonly IDataPersistence dataPersistence;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly InvestigatorsCardPresenter investigatorsCard;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;
        [Inject] private readonly CampaignsManager campaignsManager;
        [Inject] private readonly ReadyButtonPresenter readyButton;
        [Inject] private readonly InvestigatorButtonPresenter investigatorsButton;

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
            campaignsManager.InitializeCampaigns(gameType);
            investigatorsCard.InvestigatorStateResolve();
            investigatorsCard.RefreshInvestigatorsSelectability();
            investigatorsCard.RefreshInvestigatorsVisibility();
            deckCardPresenter.RefresQuantity();
            readyButton.AutoActivate();
        }
    }
}

