using Arkham.Components;
using Arkham.ScriptableObjects;

namespace Arkham.Views
{
    public interface ICampaignView
    {
        string Id { get; }
        string FirstScenarioId { get; }
        InteractableComponent Interactable { get; }
        ICampaignState CurrentState { get; set; }
        void SetImageState(UnityEngine.Sprite icon);
        void Click();
        void HoverOn();
        void HoverOff();
    }
}
