using Arkham.Controllers;
using Arkham.Views;

namespace Arkham.ScriptableObjects
{
    public interface ICampaignState
    {
        string Id { get; }
        bool IsOpen { get; }
        void ExecuteState(ICampaignView campaignView);
    }
}
