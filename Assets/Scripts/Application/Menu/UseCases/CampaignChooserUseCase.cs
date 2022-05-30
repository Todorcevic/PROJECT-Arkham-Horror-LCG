using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class CampaignChooserUseCase
    {
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly MainPanelPresenter panelPresenter;
        [Inject] private readonly MidPanelPresenter midPanelPresenter;

        /*******************************************************************/
        public void ChooseCampaign(string campaignId) => UpdateModel(campaignId);

        private void UpdateModel(string campaignId)
        {
            campaignRepository.SelectFirstScenarioOf(campaignId);
            midPanelPresenter.SelectInvestigatorsPanel();
            panelPresenter.ChooseSelectionPanel();
        }
    }
}
