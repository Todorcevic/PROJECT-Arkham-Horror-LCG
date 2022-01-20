using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartPlayUseCase
    {
        [Inject] private readonly SelectorsRepository selector;
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly DataMapperService dataPersistence;
        [Inject] private readonly SceneLoaderService sceneLoaderService;

        /*******************************************************************/
        public void Start()
        {
            UpdateModel();
            UpdateApplication();
        }

        private void UpdateModel() => selector.ReadyAllInvestigators();

        private void UpdateApplication()
        {
            dataPersistence.SaveProgress();
            sceneLoaderService.LoadScene(campaignRepository.CurrentScenario.Id);
        }
    }
}
