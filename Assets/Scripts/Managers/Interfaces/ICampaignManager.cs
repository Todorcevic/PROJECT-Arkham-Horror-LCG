using Arkham.Views;

namespace Arkham.Managers
{
    public interface ICampaignManager
    {
        void SetState(ICampaignView campaign, string idState);
    }
}

