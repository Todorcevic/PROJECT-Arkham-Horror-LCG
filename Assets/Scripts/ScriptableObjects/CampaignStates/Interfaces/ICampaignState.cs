using Arkham.Controllers;

namespace Arkham.ScriptableObjects
{
    public interface ICampaignState
    {
        string Id { get; }
        bool IsOpen { get; }
        void ExecuteState(ICampaignView campaignView);
    }
}
