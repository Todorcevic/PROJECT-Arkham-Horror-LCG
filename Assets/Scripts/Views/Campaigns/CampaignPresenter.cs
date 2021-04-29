using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class CampaignPresenter : IInitializable
    {
        [Inject] private readonly ICampaignsManager campaignManager;
        [Inject] private readonly CampaignRepository campaignRepository;
        [Inject] private readonly CampaignChangeEventDomain campaignChangedEvent;
        [Inject] private readonly StartGameEventDomain gameStartedEvent;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            gameStartedEvent.GameStarted += (_) => InitializeCampaigns();
            campaignChangedEvent.Subscribe(ExecuteStateWithCampaign);
        }

        private void InitializeCampaigns()
        {
            foreach (string campaignId in campaignRepository.CampaignsId)
            {
                string state = campaignRepository.Get(campaignId).State;
                ExecuteStateWithCampaign(campaignId, state);
            }
        }

        private void ExecuteStateWithCampaign(string campaignId, string state)
        {
            CampaignView campaign = campaignManager.GetCampaign(campaignId);
            campaignManager.GetState(state).ExecuteState(campaign);
        }
    }
}
