using Arkham.Config;
using Arkham.Services;
using Zenject;

namespace Arkham.Views
{
    public class StartGameUseCase
    {
        [Inject] private readonly IDataPersistence dataPersistence;
        [Inject] private readonly SelectorInitPresenter selectorInit;
        [Inject] private readonly ReadyButtonPresenter readyButtonPresenter;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly CampaignPresenter campaignPresenter;
        [Inject] private readonly InvestigatorStatePresenter investigatorStatePresenter;

        /*******************************************************************/
        public void Init(StartGame gameType)
        {
            dataPersistence.LoadProgress(gameType);
            selectorInit.InitializeSelectors();
            if (gameType == StartGame.New) campaignPresenter.InitializeCampaigns();
            investigatorStatePresenter.InvestigatorStateResolve();
            investigatorVisibility.RefreshInvestigatorsVisibility();
            readyButtonPresenter.UpdateButton();
        }
    }
}
