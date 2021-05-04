using Arkham.Config;
using Arkham.Model;
using Arkham.Services;
using Zenject;

namespace Arkham.Views
{
    public class StartGameUseCase
    {
        [Inject] private readonly IDataPersistence dataPersistence;
        [Inject] private readonly InvestigatorSelectorPresenter selectorInit;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly CampaignPresenter campaignPresenter;
        [Inject] private readonly InvestigatorStatePresenter investigatorStatePresenter;
        [Inject] private readonly Selector selector;
        [Inject] private readonly ReadyButtonController readyButton;

        /*******************************************************************/
        public void Init(StartGame gameType)
        {
            UpdateModel(gameType);
            UpdateView(gameType);
        }

        private void UpdateModel(StartGame gameType) => dataPersistence.LoadProgress(gameType);

        private void UpdateView(StartGame gameType)
        {
            selectorInit.InitializeSelectors(selector.Ids);
            if (gameType == StartGame.New) campaignPresenter.InitializeCampaigns();
            investigatorStatePresenter.InvestigatorStateResolve();
            investigatorVisibility.RefreshInvestigatorsVisibility();
            readyButton.Desactive(!selector.IsReady);
        }
    }
}
