namespace Arkham.Model
{
    public class CampaignStateOpen : CampaignState
    {
        public override string Id => "Open";
        public override bool IsOpen => true;
    }
}
