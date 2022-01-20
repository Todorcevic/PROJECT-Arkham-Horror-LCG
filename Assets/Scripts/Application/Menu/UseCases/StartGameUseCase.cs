using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartGameUseCase
    {
        [Inject] private readonly DataMapperService dataPersistence;
        [Inject] private readonly PanelPresenter panelPresenter;
        [Inject] private readonly CampaignsRepository campaignRepository;

        /*******************************************************************/
        public void StartNewGame()
        {
            UpdateApplication();
            UpdateView();

            void UpdateApplication()
            {
                dataPersistence.RemoveProgress();
                dataPersistence.LoadProgress();
            }

            void UpdateView() => panelPresenter.ChooseCampaignPanel();
        }

        public void ContinueGame()
        {
            if (string.IsNullOrEmpty(campaignRepository.CurrentScenario?.Id)) panelPresenter.ChooseCampaignPanel();
            else panelPresenter.ChooseCardPanel();
        }
    }
}

