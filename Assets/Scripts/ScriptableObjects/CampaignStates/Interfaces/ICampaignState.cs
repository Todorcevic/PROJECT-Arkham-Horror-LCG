using Arkham.Controllers;
using Arkham.Views;

namespace Arkham.SettingObjects
{
    public interface ICampaignState
    {
        string Id { get; }
        bool IsOpen { get; }
        void ExecuteState(ICampaignConfigurable campaignView);
    }
}
