namespace Arkham.Model
{
    public class Campaign
    {
        public string Id { get; set; }
        public CampaignState State { get; set; }
        public Scenario FirstScenario { get; set; }
    }
}
