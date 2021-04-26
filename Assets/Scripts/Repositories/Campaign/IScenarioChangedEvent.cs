using System;

namespace Arkham.Repositories
{
    public interface IScenarioChangedEvent
    {
        void Subscribe(Action<string> action);
    }
}
