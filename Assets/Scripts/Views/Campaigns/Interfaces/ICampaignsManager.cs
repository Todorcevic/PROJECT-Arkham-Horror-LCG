namespace Arkham.Views
{
    public interface ICampaignsManager
    {
        CampaignStateSO GetState(string campaignState);
        CampaignView GetCampaign(string campaignId);
    }
}
