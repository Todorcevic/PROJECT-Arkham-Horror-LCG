using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartPlayUseCase
    {
        [Inject] private readonly SelectorsRepository selector;
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly Loader loader;
        [Inject] private readonly DataMapperService dataPersistence;

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
            loader.LoadScene(campaignRepository.CurrentScenario.Id);
        }
    }
}
