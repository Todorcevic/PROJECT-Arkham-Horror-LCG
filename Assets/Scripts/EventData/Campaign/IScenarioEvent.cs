using System;

namespace Arkham.EventData
{
    public interface IScenarioEvent
    {
        void AddAction(Action<string> action);
    }
}
