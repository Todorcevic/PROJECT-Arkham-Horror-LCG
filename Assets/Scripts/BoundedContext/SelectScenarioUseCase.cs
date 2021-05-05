using Arkham.Model;
using Arkham.Views;
using Zenject;

namespace Arkham.UseCases
{
    public class SelectScenarioUseCase
    {
        [Inject] private readonly CampaignRepository campaignManager;
        [Inject] private readonly ContinueButtonController continueButton;

        /*******************************************************************/
        public void Reset()
        {
            campaignManager.CurrentScenario = null;
            continueButton.Desactive(true);
        }

        public void SelectCampaign(string campaignId)
        {
            campaignManager.CurrentScenario = campaignManager.Get(campaignId).FirstScenario;
            continueButton.Desactive(false);
        }
    }
}
