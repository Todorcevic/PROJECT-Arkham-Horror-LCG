using System;

namespace Arkham.EventData
{
    public interface IVisibilityEvent
    {
        void AddVisibilityAction(Action<bool> action);
        void AddTextChangeAction(Action<string> action);
    }
}
