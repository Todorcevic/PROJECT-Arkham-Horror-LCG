using Arkham.Model;
using Zenject;

namespace Arkham.Application
{
    public class SelectScenarioUseCase
    {
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly ContinueButtonPresenter continueButton;

        /*******************************************************************/
        public void Reset() => SelectFirstScenarioOf(null);

        public void SelectFirstScenarioOf(string campaignId)
        {
            SelectCampaignUpdateModel(campaignId);
            SelectCampaignUpdateView();
        }

        void SelectCampaignUpdateModel(string campaignId) => campaignRepository.SelectFirstScenarioOf(campaignId);

        void SelectCampaignUpdateView() => continueButton.CheckEnable();
    }
}
