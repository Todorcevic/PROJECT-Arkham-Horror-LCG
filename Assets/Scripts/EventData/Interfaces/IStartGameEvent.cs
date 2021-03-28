using System;

namespace Arkham.EventData
{
    public interface IStartGameEvent
    {
        void AddAction(Action action);
    }
}
