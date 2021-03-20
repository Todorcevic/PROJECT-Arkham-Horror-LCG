using System;

namespace Arkham.EventData
{
    public interface IVisibilityEvent
    {
        event Action<bool> VisibilityChanged;
    }
}
