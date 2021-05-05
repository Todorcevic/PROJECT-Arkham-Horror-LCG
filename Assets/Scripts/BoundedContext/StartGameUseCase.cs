using Arkham.Config;
using Arkham.Model;
using Arkham.Services;
using Arkham.Views;
using System.Collections.Generic;
using Zenject;

namespace Arkham.UseCases
{
    public class StartGameUseCase
    {
        [Inject] private readonly Selector selector;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly IDataPersistence dataPersistence;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly InvestigatorCardVisibilityPresenter investigatorVisibility;
        [Inject] private readonly CampaignPresenter campaignPresenter;
        [Inject] private readonly InvestigatorStatePresenter investigatorStatePresenter;
        [Inject(Id = "ReadyButton")] private readonly ButtonView readyButton;
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
            investigatorsButton.Execute();
            investigatorSelector.InitializeSelectors(selector.Ids);
            investigatorSelector.SetLeadSelector(selector.Lead?.Id);
            if (gameType == StartGame.New)
                campaignPresenter.InitializeCampaigns(CreateDTOList());
            investigatorStatePresenter.InvestigatorStateResolve();
            investigatorVisibility.RefreshInvestigatorsSelectability();
            investigatorVisibility.RefreshInvestigatorsVisibility();
            readyButton.Desactive(!selector.IsReady);
        }

        private List<CampaignDTO> CreateDTOList()
        {
            List<CampaignDTO> allCampaigns = new List<CampaignDTO>();
            foreach (Campaign campaign in campaignRepository.Campaigns)
                allCampaigns.Add(new CampaignDTO(campaign.Id, campaign.State.Id, campaign.State.IsOpen));
            return allCampaigns;
        }
    }
}
