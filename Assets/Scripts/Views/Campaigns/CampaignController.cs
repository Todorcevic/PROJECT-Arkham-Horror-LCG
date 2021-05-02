using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class CampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly PanelsManagerComponent panelsManager;
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
