using Arkham.Components;

namespace Arkham.Views
{
    public interface ICampaignView
    {
        string Id { get; }
        string FirstScenarioId { get; }
        bool IsOpen { get; set; }
        InteractableComponent Interactable { get; }
        void Init();
        void ChangeIconState(UnityEngine.Sprite icon);
    }
}
