using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SelectScenarioUseCase
    {
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject(Id = "ContinueButton")] private readonly ButtonView continueButton;

        /*******************************************************************/
        public void Reset() => SelectFirstScenarioOf(null);

        public void SelectFirstScenarioOf(string campaignId)
        {
            SelectCampaignUpdateModel(campaignId);
            SelectCampaignUpdateView();
        }

        private void SelectCampaignUpdateModel(string campaignId) => campaignRepository.SelectFirstScenarioOf(campaignId);

        private void SelectCampaignUpdateView() => continueButton.Desactive(campaignRepository.CurrentScenario == null);
    }
}
