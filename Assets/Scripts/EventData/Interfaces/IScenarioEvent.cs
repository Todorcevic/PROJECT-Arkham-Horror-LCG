using System;

namespace Arkham.EventData
{
    public interface IScenarioEvent
    {
        event Action<string> CurrentScenarioChanged;
    }
}
