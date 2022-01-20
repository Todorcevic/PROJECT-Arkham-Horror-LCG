using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class SelectScenarioUseCase
    {
        [Inject] private readonly CampaignsRepository campaignRepository;
        [Inject] private readonly PanelPresenter panelPresenter;

        /*******************************************************************/
        public void SelectFirstScenarioOf(string campaignId) => UpdateModel(campaignId);

        private void UpdateModel(string campaignId)
        {
            campaignRepository.SelectFirstScenarioOf(campaignId);
            panelPresenter.ChooseCardPanel();
        }
    }
}
