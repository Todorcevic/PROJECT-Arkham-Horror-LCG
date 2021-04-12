using System;

namespace Arkham.EventData
{
    public interface IVisibilityEvent
    {
        void AddAction(Action<bool> action);
    }
}
