using Arkham.Config;
using Arkham.Model;
using Arkham.Services;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class StartGameUseCase
    {
        [Inject] private readonly Selector selector;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly InvestigatorRepository investigatorRepository;
        [Inject] private readonly IDataPersistence dataPersistence;
        [Inject] private readonly InvestigatorSelectorPresenter investigatorSelector;
        [Inject] private readonly InvestigatorsCardPresenter investigatorsCard;
        [Inject] private readonly CampaignPresenter campaignPresenter;
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
            investigatorsButton.ExecuteClick();
            investigatorSelector.InitializeSelectors(selector.Ids);
            investigatorSelector.SetLeadSelector(selector.Lead?.Id);
            if (gameType == StartGame.New) campaignPresenter.InitializeCampaigns(CreateCampaignsDTOList());
            investigatorsCard.InvestigatorStateResolve(CreateInvestigatorsStateDTO());
            investigatorsCard.RefreshInvestigatorsSelectability();
            investigatorsCard.RefreshInvestigatorsVisibility();
            readyButton.Desactive(!selector.IsReady);
        }

        private List<CampaignDTO> CreateCampaignsDTOList()
        {
            List<CampaignDTO> allCampaigns = new List<CampaignDTO>();
            foreach (Campaign campaign in campaignRepository.Campaigns)
                allCampaigns.Add(new CampaignDTO(campaign.Id, campaign.State.Id, campaign.State.IsOpen));
            return allCampaigns;
        }

        private List<InvestigatorStateDTO> CreateInvestigatorsStateDTO()
        {
            List<InvestigatorStateDTO> allinvestigators = new List<InvestigatorStateDTO>();

            foreach (Investigator investigator in investigatorRepository.Investigators)
                allinvestigators.Add(new InvestigatorStateDTO(investigator.Id, investigator.State));
            return allinvestigators;
        }
    }
}

