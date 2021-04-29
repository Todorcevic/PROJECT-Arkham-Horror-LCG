namespace Arkham.Views
{
    public interface ICampaignsManager
    {
        CampaignState GetState(string campaignState);
        CampaignView GetCampaign(string campaignId);
    }
}
