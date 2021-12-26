using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class StartPlayUseCase
    {
        [Inject] private readonly SelectorRepository selector;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly Loader loader;

        /*******************************************************************/
        public void Start()
        {
            UpdateModel();
            UpdateView();
        }

        private void UpdateModel() => selector.ReadyAllInvestigators();

        private void UpdateView() => loader.LoadScene(campaignRepository.CurrentScenario.Id);
    }
}
