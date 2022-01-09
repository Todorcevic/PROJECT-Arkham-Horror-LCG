using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SelectScenarioUseCase
    {
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly ButtonsPresenter buttonsPresenter;

        /*******************************************************************/
        public void Reset() => SelectFirstScenarioOf(null);

        public void SelectFirstScenarioOf(string campaignId)
        {
            UpdateModel(campaignId);
            UpdateView();
        }

        private void UpdateModel(string campaignId) => campaignRepository.SelectFirstScenarioOf(campaignId);

        private void UpdateView() => buttonsPresenter.AutoActivateContinueButton();
    }
}
