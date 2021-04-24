using Arkham.EventData;
using Arkham.Repositories;
using Zenject;

namespace Arkham.View
{
    public class CampaignController : ICampaignController
    {
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "ChooseCardPanel")] private readonly PanelView panelToShow;
        [Inject] private readonly ICampaignRepository campaignRepository;
        [Inject] private readonly IChangeScenario changeScenario;

        /*******************************************************************/
        public void Clicked(string campaignId)
        {
            ChangeToFirstScenario(campaignId);
            panelsManager.SelectPanel(panelToShow);
        }

        private void ChangeToFirstScenario(string campaignId)
        {
            string firstScenario = campaignRepository.GetCampaign(campaignId).FirstScenario;
            changeScenario.SelectingScenario(firstScenario);
        }
    }
}
