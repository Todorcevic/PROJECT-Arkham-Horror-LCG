using Zenject;

namespace Arkham.Application
{
    public class CampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly SelectScenarioUseCase scenarioEvent;

        /*******************************************************************/
        public void Clicked(string campaignId)
        {
            scenarioEvent.SelectCampaign(campaignId);
            panelsManager.SelectPanel(panelToShow);
        }
    }
}
