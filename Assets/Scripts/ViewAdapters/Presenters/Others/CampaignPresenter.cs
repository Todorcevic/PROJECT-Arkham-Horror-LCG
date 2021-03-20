using Arkham.Managers;
using Arkham.EventData;
using Zenject;
using Arkham.Views;
using Arkham.Interactors;

namespace Arkham.Presenters
{
    public class CampaignPresenter : IInitializable
    {
        [Inject] private readonly ICampaignInteractor campaignInteractor;
        [Inject] private readonly ICampaignsManager campaignsManager;
        [Inject] private readonly ICampaignEvent changeCampaignEventData;
        [Inject] private readonly IStartGameEvent startGameEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            changeCampaignEventData.CampaignStateChanged += ExecuteStateWithCampaign;
            startGameEvent.GameStarted += InitializeCampaigns;
        }

        /*******************************************************************/
        private void InitializeCampaigns()
        {
            foreach (string campaignId in campaignInteractor.CampaignsList)
            {
                string state = campaignInteractor.GetState(campaignId);
                ExecuteStateWithCampaign(campaignId, state);
            }
        }

        private void ExecuteStateWithCampaign(string campaignId, string state)
        {
            CampaignView campaignView = campaignsManager.GetCampaign(campaignId);
            campaignsManager.GetState(state).ExecuteState(campaignView);
        }
    }
}
