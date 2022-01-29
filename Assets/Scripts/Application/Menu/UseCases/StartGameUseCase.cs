using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartGameUseCase
    {
        [Inject] private readonly DataMapperService dataPersistence;
        [Inject] private readonly MainPanelPresenter panelPresenter;
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
            if (campaignRepository.IsNotScenario) panelPresenter.ChooseCampaignPanel();
            else panelPresenter.ChooseSelectionPanel();
        }
    }
}

