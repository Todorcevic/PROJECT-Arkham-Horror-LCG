namespace Arkham.Repositories
{
    public interface ICampaignRepository
    {
        void SelectScenario(string scenario);
        void ChangeCampaignState(string campaignId, string state);
        void SelectFirstScenarioOf(string campaignId);
    }
}
