using Arkham.Model;
using Arkham.Application;
using Zenject;

namespace Arkham.Application
{
    public class SelectScenarioUseCase
    {
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly ContinueButtonPresenter continueButton;

        /*******************************************************************/

        public void ResetInit()
        {
            ResetUpdateModel();
            ResetUpdateView();
        }

        void ResetUpdateModel() => campaignRepository.CurrentScenario = null;

        void ResetUpdateView() => continueButton.Desactive(true);


        public void SelectCampaignInit(string campaignId)
        {
            SelectCampaignUpdateModel(campaignId);
            SelectCampaignUpdateView();
        }

        void SelectCampaignUpdateModel(string campaignId) => campaignRepository.CurrentScenario = campaignRepository.Get(campaignId).FirstScenario;

        void SelectCampaignUpdateView() => continueButton.Desactive(false);
    }
}
