using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class CampaignController : ICampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly ScenarioEventDomain scenarioEvent;
        /*******************************************************************/
        public void Clicked(string campaignId)
        {
            scenarioEvent.SelectCampaign(campaignId);
            panelsManager.SelectPanel(panelToShow);
        }
    }
}
