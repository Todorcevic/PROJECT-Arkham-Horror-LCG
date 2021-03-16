using System;

namespace Arkham.EventData
{
    public interface IStartGameEvent
    {
        event Action GameStarted;
    }
}
