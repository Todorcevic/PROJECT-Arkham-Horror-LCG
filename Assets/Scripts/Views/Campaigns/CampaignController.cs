using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class CampaignController : ICampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly CampaignChangeEventDomain currentScenario;
        /*******************************************************************/
        public void Clicked(string campaignId)
        {
            string scenario = campaignRepository.Get(campaignId).FirstScenario;
            currentScenario.Select(scenario);
            panelsManager.SelectPanel(panelToShow);
        }
    }
}
