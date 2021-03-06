namespace Arkham.EventData
{
    public interface IChangeCampaign
    {
        void ChangeCampaignState(string campaignId, string state);
        void SelectScenario(string scenarioId);
    }
}
