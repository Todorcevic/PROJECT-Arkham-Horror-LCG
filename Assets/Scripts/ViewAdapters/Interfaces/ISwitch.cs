using System;
using UnityEngine.EventSystems;

namespace Arkham.Views
{
    public interface ISwitch
    {
        bool SaveValue { get; }
        void AddEvent(Action<PointerEventData> action);
        void ClickSound();
        void AnimateSwitch(bool isOn);
    }
}
