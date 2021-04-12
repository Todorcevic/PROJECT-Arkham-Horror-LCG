using System;

namespace Arkham.EventData
{
    public interface IRemoveCardEvent
    {
        void AddAction(Action<string> action);
    }
}
