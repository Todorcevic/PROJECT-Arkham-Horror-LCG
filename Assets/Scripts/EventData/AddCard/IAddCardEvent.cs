using System;

namespace Arkham.EventData
{
    public interface IAddCardEvent
    {
        void AddAction(Action<string> action);
    }
}
