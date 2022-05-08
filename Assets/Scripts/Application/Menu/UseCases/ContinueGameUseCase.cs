using Arkham.Model;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class ContinueGameUseCase
    {
        [Inject] private readonly MainPanelPresenter panelPresenter;
        [Inject] private readonly CampaignsRepository campaignRepository;

        /*******************************************************************/
        public void ContinueGame()
        {
            if (campaignRepository.IsScenarioFinished) panelPresenter.ChooseCampaignPanel();
            else panelPresenter.ChooseSelectionPanel();
        }
    }
}
