using Zenject;
using Arkham.Adapter;
using Arkham.Model;

namespace Arkham.Views
{
    public class CampaignController : ICampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly ScenarioEventDomain scenarioEvent;
        [Inject] private readonly CampaignRepository campaignRepository;

        /*******************************************************************/
        public void Clicked(CampaignView campaign)
        {
            if (!campaignRepository.Get(campaign.Id).State.IsOpen) return;
            campaign.ClickEffect();
            scenarioEvent.SelectCampaign(campaign.Id);
            panelsManager.SelectPanel(panelToShow);
        }
    }
}
