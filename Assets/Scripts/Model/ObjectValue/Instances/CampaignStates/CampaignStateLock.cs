namespace Arkham.Model
{
    public class CampaignStateLock : CampaignState
    {
        public override string Id => "Lock";
        public override bool IsOpen => false;
    }
}
