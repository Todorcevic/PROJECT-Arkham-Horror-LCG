using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class CampaignController : ICampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly ICampaignRepository campaignRepository;

        /*******************************************************************/
        public void Clicked(string campaignId)
        {
            campaignRepository.SelectFirstScenarioOf(campaignId);
            panelsManager.SelectPanel(panelToShow);
        }
    }
}
