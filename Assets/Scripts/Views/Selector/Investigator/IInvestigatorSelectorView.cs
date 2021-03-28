using UnityEngine;
using UnityEngine.EventSystems;

namespace Arkham.Views
{
    public interface IInvestigatorSelectorView : ISelectorView
    {
        bool IsLeader { get; }
        void LeadIcon(bool isOn);
        void BeginDragEffect();
        void DraggingEffect(Vector2 movePosition);
        void EndDragEffect();
        void DoubleClickEffect();
        void ClickEffect();
        void HoverOnEffect();
        void HoverOffEffect();
        void HoverOnAudio();
    }
}
